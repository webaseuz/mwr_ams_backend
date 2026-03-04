using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class FixedMinimumValueDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
