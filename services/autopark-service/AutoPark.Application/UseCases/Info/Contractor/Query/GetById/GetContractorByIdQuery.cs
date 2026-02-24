using MediatR;

namespace AutoPark.Application.UseCases.Info.Contractors;

public class GetContractorByIdQuery :
    IRequest<ContractorDto>
{
    public int Id { get; set; }
}
