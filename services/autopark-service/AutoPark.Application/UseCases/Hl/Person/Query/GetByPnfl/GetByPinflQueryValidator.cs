using FluentValidation;

namespace AutoPark.Application.UseCases.Persons;

public class GetByPinflQueryValidator :
    AbstractValidator<GetPersonByPinflQuery>
{
    public GetByPinflQueryValidator()
    {
        /*RuleFor(x => x.Pinfl)
        .NotNull()
        .Length(14)
        .Matches(@"^\d{14}$")
        .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetPersonByPinflQuery.Pinfl), 14, 14));*/

    }
}
