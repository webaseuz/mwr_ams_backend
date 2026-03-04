using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class DistrictDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}



