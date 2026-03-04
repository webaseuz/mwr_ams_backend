using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class CountryDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
