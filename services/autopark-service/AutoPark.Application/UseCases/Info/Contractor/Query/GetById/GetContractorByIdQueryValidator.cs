using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Info.Contractors;

public class GetContractorByIdQueryValidator :
     AbstractValidator<GetContractorByIdQuery>
{
    public GetContractorByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GetContractorByIdQuery.Id)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetContractorByIdQuery.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetContractorByIdQuery.Id), 1, int.MaxValue));
    }
}
