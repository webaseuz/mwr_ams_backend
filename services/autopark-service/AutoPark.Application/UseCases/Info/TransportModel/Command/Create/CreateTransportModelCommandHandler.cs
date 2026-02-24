using AutoPark.Application.Security;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.MinioSdk;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;


namespace AutoPark.Application.UseCases.TransportModels;

public class CreateTransportModelCommandHandler :
    IRequestHandler<CreateTransportModelCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IAsyncAppAuthService _authService;

    public CreateTransportModelCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IStorageAsyncService storageAsyncService,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _storageAsyncService = storageAsyncService;
        _authService = authService;
    }

    public async Task<IHaveId<int>> Handle(
    CreateTransportModelCommand request,
    CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            // 1. Create and save TransportModel first
            var transportModel = request.CreateEntity<CreateTransportModelCommand, TransportModel>(_mapper);
            request.Translates.AddByUniqueFKTo(transportModel.Translates, _mapper);
            transportModel.MarkAsActive();

            // set TransportModel Fluid entities
            request.Liquids.AddTo(transportModel.Liquids, _mapper);
            request.Fuels.AddTo(transportModel.Fuels, _mapper);
            request.Oils.AddTo(transportModel.Oils, _mapper);

            // 3. Handle files
            transportModel.Files.AddFromTempFiles(
                document: FileStorageConst.TRANSPORT_MODEL_FILE,
                tempFileIds: request.Files.Select(x => x.Id).ToList(),
                onAddEntity: file =>
                {
                    var original = request.Files.FirstOrDefault(x => x.Id == file.Id);
                    if (original != null)
                    {
                        file.TransportColorId = original.TransportColorId;
                    }
                });

            await _context.AddAsync(transportModel, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            // 4. Move files to permanent storage
            if (request.Files.Any())
            {
                await _storageAsyncService.MoveToPersistentAsync(
                    document: FileStorageConst.TRANSPORT_MODEL_FILE,
                    documentId: transportModel.Id.ToString(),
                    tempFileIds: [.. request.Files.Select(x => x.Id)]);
            }

            await transaction.CommitAsync(cancellationToken);
            return HaveId.Create(transportModel.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}