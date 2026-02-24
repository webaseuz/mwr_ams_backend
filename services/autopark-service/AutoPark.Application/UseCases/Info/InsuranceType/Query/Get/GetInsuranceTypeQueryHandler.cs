using MediatR;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class GetInsuranceTypeQueryHandler :
    IRequestHandler<GetInsuranceTypeQuery, InsuranceTypeDto>
{
    public Task<InsuranceTypeDto> Handle(
        GetInsuranceTypeQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new InsuranceTypeDto());
}
