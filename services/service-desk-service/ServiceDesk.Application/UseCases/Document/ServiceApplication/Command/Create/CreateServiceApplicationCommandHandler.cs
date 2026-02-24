using Bms.Core.Application.Mapping;
using Bms.WEBASE.MinioSdk;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.Security;
using ServiceDesk.Application.UseCases.Services.HistoryService;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class CreateServiceApplicationCommandHandler :
    IRequestHandler<CreateServiceApplicationCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly INumberService _numberService;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IAsyncAppAuthService _authService;
    private readonly IDocumentHistoryService _documentHistoryService;

    public CreateServiceApplicationCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        INumberService numberService,
        IStorageAsyncService storageAsyncService,
        IDocumentHistoryService documentHistoryService,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _numberService = numberService;
        _storageAsyncService = storageAsyncService;
        _authService = authService;
        _documentHistoryService = documentHistoryService;
    }

    public async Task<IHaveId<long>> Handle(
        CreateServiceApplicationCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var docNumberResult = _numberService.GetNext(NumberTamplateDocumentConst.SERVICE_APPLICATION);

            var entity = request.CreateEntity<CreateServiceApplicationCommand, ServiceApplication>(_mapper);

            entity.DocNumber = docNumberResult.docNumber;

            if (request.BranchId is null)
            {
                var user = await _authService.GetUserAsync();

                var branch = await _context.Branches
                    .FirstOrDefaultAsync(r => r.Id == user.BranchId, cancellationToken);

                if (branch != null)
                {
                    entity.BranchId = branch.Id;
                }
            }

            entity.Create();

            //request.ExecutorFiles.AddTo(entity.ServiceApplicationExecutorFiles, _mapper);
            request.Parts.AddTo(entity.ServiceApplicationParts, _mapper);
            //request.Files.AddTo(entity.ServiceApplicationFiles, _mapper);

            entity.ServiceApplicationFiles.AddFromTempFiles(document: FileStorageConst.SERVICE_APPLICATION_FILE,
                                          tempFileIds: request.Files.Select(x => x.Id).ToList());

            var result = await _context.CreateAndSaveAsync<long, ServiceApplication>(entity, cancellationToken);

            if (request.Files.Any())
                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.SERVICE_APPLICATION_FILE,
                                                                 documentId: entity.Id.ToString(),
                                                                 tempFileIds: [.. request.Files.Select(x => x.Id)]);

            try
            {
                var entityById = await _mapper.MapCollection<ServiceApplication, ServiceApplicationDto>(_context.ServiceApplications)
                    .FirstOrDefaultAsync(r => r.Id == entity.Id, cancellationToken);

                // Create HistoryEntity and UploadMinio
                var historyFileId = await _documentHistoryService.AddHistory<long, ServiceApplication, ServiceApplicationDto>(entityById, cancellationToken);

                // Move files to persistent storage to Main storage
                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.SERVICE_APPLICATION_HISTORY,
                                                                         documentId: entity.Id.ToString(),
                                                                         tempFileIds: historyFileId);

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }

            await transaction.CommitAsync(cancellationToken);

            return HaveId.Create(entity.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
