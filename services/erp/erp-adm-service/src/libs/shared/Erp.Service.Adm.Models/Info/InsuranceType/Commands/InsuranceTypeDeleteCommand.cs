using MediatR;

namespace Erp.Service.Adm.Models;

public class InsuranceTypeDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
