using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class GetInsuranceTypeByIdQueryValidator :
    AbstractValidator<GetInsuranceTypeByIdQuery>
{
    public GetInsuranceTypeByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetInsuranceTypeByIdQuery.Id), 1, int.MaxValue));
    }
}