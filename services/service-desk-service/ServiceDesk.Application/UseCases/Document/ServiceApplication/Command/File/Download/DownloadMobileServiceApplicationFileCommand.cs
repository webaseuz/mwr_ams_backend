using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bms.WEBASE.Storage;
using MediatR;

namespace ServiceDesk.Application.UseCases.Document.ServiceApplications;

public class DownloadMobileServiceApplicationFileCommand : IRequest<StorageFile>
{
    public Guid FileId { get; set; }
    public DownloadMobileServiceApplicationFileCommand(Guid fileId)
    {
        this.FileId = fileId;
    }
}
