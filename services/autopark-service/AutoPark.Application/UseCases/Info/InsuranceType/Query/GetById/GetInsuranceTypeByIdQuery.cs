using MediatR;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class GetInsuranceTypeByIdQuery :
    IRequest<InsuranceTypeDto>
{
    public int Id { get; set; }
}