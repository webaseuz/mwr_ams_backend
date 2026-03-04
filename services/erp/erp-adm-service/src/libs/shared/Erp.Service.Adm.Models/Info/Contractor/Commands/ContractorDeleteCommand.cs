using MediatR;

namespace Erp.Service.Adm.Models;

public class ContractorDeleteCommand : IRequest<bool>
{
    public long Id { get; set; }
}
