using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Expenses;

public class UploadExpenseTablesFileCommandValidator :
    AbstractValidator<UploadExpenseTablesFileCommand>
{
    public UploadExpenseTablesFileCommandValidator()
    {
        RuleFor(x => x.Files)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UploadExpenseTablesFileCommand.Files)));

        RuleFor(x => x.DocumentName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UploadExpenseTablesFileCommand.DocumentName)));
    }
}
