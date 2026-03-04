using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class FixedMinimumValueGetByIdQuery : IRequest<FixedMinimumValueDto>
{
    public long Id { get; set; }

}
