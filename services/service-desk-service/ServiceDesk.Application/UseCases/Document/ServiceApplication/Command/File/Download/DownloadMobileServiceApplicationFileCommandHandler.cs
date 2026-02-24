using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.UseCases.ServiceApplications;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.Document.ServiceApplications;

public class DownloadMobileServiceApplicationFileCommandHandler :
    IRequestHandler<DownloadMobileServiceApplicationFileCommand, StorageFile>
{

    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IReadEfCoreContext _context;

    public DownloadMobileServiceApplicationFileCommandHandler(IStorageAsyncService storageAsyncService, IReadEfCoreContext context)
    {
        _storageAsyncService = storageAsyncService;
        _context = context;
    }

    public async Task<StorageFile> Handle(
        DownloadMobileServiceApplicationFileCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.ServiceApplicationFiles
            .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);

        StorageFile file;
        string document = FileStorageConst.SERVICE_APPLICATION_FILE;

        if(entity is null)
            file = await _storageAsyncService.GetTempFileAsync(document, request.FileId);
        else
        {
            file = await _storageAsyncService.GetFileAsync(document, entity.OwnerId.ToString(), request.FileId);
            file.FileName = entity.FileName;
        }

        return file != null ? file : null;
    }
}
