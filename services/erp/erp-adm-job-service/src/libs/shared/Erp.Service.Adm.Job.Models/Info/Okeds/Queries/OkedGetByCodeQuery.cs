using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class OkedGetByCodeQuery : IRequest<int?>
{
    public string Code { get; set; } = null;
}


