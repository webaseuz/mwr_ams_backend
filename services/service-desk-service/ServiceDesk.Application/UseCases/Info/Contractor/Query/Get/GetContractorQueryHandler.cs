using MediatR;

namespace ServiceDesk.Application.UseCases.Info.Contractors;

public class GetContractorQueryHandler :
     IRequestHandler<GetContractorQuery, ContractorDto>
{
    public Task<ContractorDto> Handle(
           GetContractorQuery request,
           CancellationToken cancellationToken)
           => Task.FromResult(new ContractorDto());
}
