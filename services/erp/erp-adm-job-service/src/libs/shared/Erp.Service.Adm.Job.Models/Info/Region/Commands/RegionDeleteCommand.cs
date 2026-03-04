using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class RegionDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
