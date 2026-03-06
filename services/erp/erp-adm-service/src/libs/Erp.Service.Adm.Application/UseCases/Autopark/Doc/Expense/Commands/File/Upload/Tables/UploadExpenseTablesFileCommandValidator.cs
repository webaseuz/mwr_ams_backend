using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UploadExpenseTablesFileCommandValidator :
    AbstractValidator<ExpenseTablesFileUploadCommand>
{
    public UploadExpenseTablesFileCommandValidator()
    {
        RuleFor(x => x.Files)
            .NotEmpty()
            .WithMessage($"{nameof(ExpenseTablesFileUploadCommand.Files)} is required");

        RuleFor(x => x.DocumentName)
            .NotEmpty()
            .WithMessage($"{nameof(ExpenseTablesFileUploadCommand.DocumentName)} is required");
    }
}
