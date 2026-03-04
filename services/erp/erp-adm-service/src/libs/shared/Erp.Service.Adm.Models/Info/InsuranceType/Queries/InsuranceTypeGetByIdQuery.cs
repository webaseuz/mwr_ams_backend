using MediatR;

namespace Erp.Service.Adm.Models;

public class InsuranceTypeGetByIdQuery : IRequest<InsuranceTypeDto>
{
    public int Id { get; set; }
}
