using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class GetExpenseByIdQueryValidator :
    AbstractValidator<ExpenseGetByIdQuery>
{
    public GetExpenseByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage($"{nameof(ExpenseGetByIdQuery.Id)} is required")
            .GreaterThan(0)
            .WithMessage($"{nameof(ExpenseGetByIdQuery.Id)} must be between 1 and {int.MaxValue}")
            .LessThan(long.MaxValue)
            .WithMessage($"{nameof(ExpenseGetByIdQuery.Id)} must be between 1 and {int.MaxValue}");
    }
}
