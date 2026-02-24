using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Persons;

public class GetPersonByIdQueryValidator :
    AbstractValidator<GetPersonByIdQuery>
{
    public GetPersonByIdQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotNull()
           .GreaterThan(0)
           .LessThan(int.MaxValue)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetPersonByIdQuery.Id), 1, int.MaxValue));
    }
}
