using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UploadExpenseFileCommandValidator :
    AbstractValidator<ExpenseFileUploadCommand>
{
    public UploadExpenseFileCommandValidator()
    {
        RuleFor(x => x.Files)
            .NotEmpty()
            .WithMessage($"{nameof(ExpenseFileUploadCommand.Files)} is required");
    }
}
