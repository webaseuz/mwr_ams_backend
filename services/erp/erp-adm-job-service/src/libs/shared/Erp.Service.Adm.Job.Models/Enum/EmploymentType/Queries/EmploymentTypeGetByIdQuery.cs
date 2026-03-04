using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class EmploymentTypeGetByIdQuery : IRequest<EmploymentTypeDto>
{
    public int Id { get; set; }
}
