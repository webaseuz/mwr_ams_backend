using MediatR;

namespace Erp.Service.Adm.Models;

public class DistrictGetByIdQuery : IRequest<DistrictDto>
{
    public int Id { get; set; }
}
