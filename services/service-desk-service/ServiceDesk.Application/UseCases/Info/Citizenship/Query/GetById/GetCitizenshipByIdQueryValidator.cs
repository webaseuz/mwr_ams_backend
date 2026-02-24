using ServiceDesk.Application.UseCases.Banks;
using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class GetCitizenshipByIdQueryValidator :
    AbstractValidator<GetCitizenshipByIdQuery>
{
    public GetCitizenshipByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetBankByIdQuery.Id), 1, int.MaxValue));
    }
}