using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class PersonGetByIdQuery : IRequest<PersonDto>
{
    public int Id { get; set; }
}


public class PersonGetPhotoFromGSPQuery : IRequest<string>
{
    public int Id { get; set; }
}
