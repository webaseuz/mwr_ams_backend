using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class InstitutionTypeGetByIdQuery : IRequest<InstitutionTypeDto>
{
    public int Id { get; set; }
}
