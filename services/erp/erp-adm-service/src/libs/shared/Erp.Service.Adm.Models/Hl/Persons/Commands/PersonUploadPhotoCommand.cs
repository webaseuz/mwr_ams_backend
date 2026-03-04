using Erp.Service.Adm.Models;
using MediatR;

namespace Erp.Service.Adm.Models;

public class PersonUploadPhotoCommand : IRequest<Guid?>
{
    public int PersonId { get; set; }

    public DocumentFileCreateDto File { get; set; }
}
