using FluentValidation;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class CreateExpenseCommandValidator :
    AbstractValidator<ExpenseCreateCommand>
{
    public CreateExpenseCommandValidator()
    {
        RuleFor(x => x.DocDate)
            .NotNull()
            .WithMessage($"{nameof(ExpenseCreateCommand.DocDate)} is required");

        RuleFor(x => x.DriverId)
            .NotNull()
            .WithMessage($"{nameof(ExpenseCreateCommand.DriverId)} is required");

        RuleFor(x => x.TransportId)
            .NotNull()
            .WithMessage($"{nameof(ExpenseCreateCommand.TransportId)} is required");
    }
}
