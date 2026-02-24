using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Currencies;

public class GetCurrencyByIdQueryValidator :
    AbstractValidator<GetCurrencyByIdQuery>
{
    public GetCurrencyByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetCurrencyByIdQuery.Id), 1, int.MaxValue));
    }
}
