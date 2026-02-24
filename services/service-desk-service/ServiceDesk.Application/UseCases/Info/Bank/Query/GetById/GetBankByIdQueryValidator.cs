using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Banks;

public class GetBankByIdQueryValidator :
    AbstractValidator<GetBankByIdQuery>
{
    public GetBankByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetBankByIdQuery.Id), 1, int.MaxValue));
    }
}