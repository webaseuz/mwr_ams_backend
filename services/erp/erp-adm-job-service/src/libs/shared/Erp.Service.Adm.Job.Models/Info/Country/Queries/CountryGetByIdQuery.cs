using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class CountryGetByIdQuery : IRequest<CountryDto>
{
    public int Id { get; set; }
}
