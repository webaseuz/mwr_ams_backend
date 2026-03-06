using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UpdateExpenseCommandValidator :
    AbstractValidator<ExpenseUpdateCommand>
{
    public UpdateExpenseCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage($"{nameof(ExpenseUpdateCommand.Id)} is required");

        RuleFor(x => x.DocDate)
            .NotNull()
            .WithMessage($"{nameof(ExpenseUpdateCommand.DocDate)} is required");

        RuleFor(x => x.DriverId)
            .NotNull()
            .WithMessage($"{nameof(ExpenseUpdateCommand.DriverId)} is required");

        RuleFor(x => x.TransportId)
            .NotNull()
            .WithMessage($"{nameof(ExpenseUpdateCommand.TransportId)} is required");
    }
}
