using MediatR;

namespace Erp.Service.Adm.Models;

public class ContractorGetByIdQuery : IRequest<ContractorDto>
{
    public long Id { get; set; }
}
