using Erp.Core.Models;
using Erp.Core.Sdk.Models;
using MediatR;

namespace Erp.Service.Adm.Models;
public class PersonGetByIdQuery : IRequest<PersonFullDto>
{
    public int Id { get; set; }
    public bool IsDocChangeLog { get; set; }
}


public class PersonGetPhotoFromGSPQuery : IRequest<string>
{
    public int Id { get; set; }
    public bool IsForceUpdate { get; set; } = false;
    public bool IsDocChangeLog { get; set; }
}
