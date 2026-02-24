using MediatR;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class GetInsuranceTypeQuery :
    IRequest<InsuranceTypeDto>
{ }
