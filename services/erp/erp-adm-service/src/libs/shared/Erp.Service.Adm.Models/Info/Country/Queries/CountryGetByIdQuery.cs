using MediatR;

namespace Erp.Service.Adm.Models;

public class CountryGetByIdQuery : IRequest<CountryDto>
{
    public int Id { get; set; }
}
