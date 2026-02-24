using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Drivers;

public class GetDriverByIdQueryValidator :
    AbstractValidator<GetDriverByIdQuery>
{
    public GetDriverByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GetDriverByIdQuery.Id)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetDriverByIdQuery.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetDriverByIdQuery.Id), 1, int.MaxValue));
    }
}
