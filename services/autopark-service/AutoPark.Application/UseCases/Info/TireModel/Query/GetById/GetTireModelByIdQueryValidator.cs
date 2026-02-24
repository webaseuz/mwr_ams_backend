using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TireModels;

public class GetTireModelByIdQueryValidator :
    AbstractValidator<GetTireModelByIdQuery>
{
    public GetTireModelByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GetTireModelByIdQuery.Id)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetTireModelByIdQuery.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetTireModelByIdQuery.Id), 1, int.MaxValue));
    }
}
