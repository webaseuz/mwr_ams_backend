using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.MinioSdk;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportModels;

public class UpdateTransportModelCommandHandler :
    IRequestHandler<UpdateTransportModelCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;
    public UpdateTransportModelCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IStorageAsyncService storageAsyncService)
    {
        _context = context;
        _mapper = mapper;
        _storageAsyncService = storageAsyncService;
    }

    public async Task<IHaveId<int>> Handle(
        UpdateTransportModelCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = await _context.TransportModels
            .Include(p => p.Files)
            .Include(x => x.Liquids)
            .Include(x => x.Oils)
            .Include(x => x.Fuels)
            .IsSoftActive()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (entity == null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            request.Translates.ApplyChangesByUniqueFKTo(entity.Translates, _mapper);

            entity.Files.UpdateFromFiles(
                document: FileStorageConst.TRANSPORT_MODEL_FILE,
                documentId: entity.Id.ToString(),
                files: request.Files.Select(x => x.Id).ToList(),
                context: _context,
                onAddEntity: file =>
                {
                    var original = request.Files.FirstOrDefault(x => x.Id == file.Id);
                    if (original != null)
                    {
                        file.TransportColorId = original.TransportColorId;
                    }
                });

            request.UpdateEntity(entity, _mapper);
            request.Liquids.ApplyChangesTo<int, UpdateTransportModelLiquidCommand, TransportModelLiquid>(entity.Liquids, _mapper);
            request.Fuels.ApplyChangesTo<int, UpdateTransportModelFuelCommand, TransportModelFuel>(entity.Fuels, _mapper);
            request.Oils.ApplyChangesTo<int, UpdateTransportModelOilCommand, TransportModelOil>(entity.Oils, _mapper);

            await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.TRANSPORT_MODEL_FILE,
                                                   documentId: request.Id.ToString());

            //request.UpdateEntity(entity, _mapper);

            await _context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync();
            return HaveId.Create(request.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
