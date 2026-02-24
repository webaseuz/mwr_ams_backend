using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Nationalities;

public class GetNationalityByIdValidator :
    AbstractValidator<GetNationalityByIdQuery>
{
    public GetNationalityByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetNationalityByIdQuery.Id), 1, int.MaxValue));
    }
}
