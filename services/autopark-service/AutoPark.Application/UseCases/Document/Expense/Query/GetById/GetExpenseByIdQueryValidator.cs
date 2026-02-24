using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Expenses;

public class GetExpenseByIdQueryValidator :
    AbstractValidator<GetExpenseByIdQuery>
{
    public GetExpenseByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GetExpenseByIdQuery.Id)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetExpenseByIdQuery.Id), 1, int.MaxValue))
            .LessThan(long.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetExpenseByIdQuery.Id), 1, int.MaxValue));
    }
}
