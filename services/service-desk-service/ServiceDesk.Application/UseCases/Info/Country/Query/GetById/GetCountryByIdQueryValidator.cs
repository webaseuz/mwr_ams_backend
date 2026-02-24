using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Countries;

public class GetCountryByIdQueryValidator :
    AbstractValidator<GetCountryByIdQuery>
{
    public GetCountryByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetCountryByIdQuery.Id), 1, int.MaxValue));
    }
}
