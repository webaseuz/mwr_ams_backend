using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Expenses;

public class UploadExpenseFileCommandValidator :
    AbstractValidator<UploadExpenseFileCommand>
{
    public UploadExpenseFileCommandValidator()
    {
        RuleFor(x => x.Files)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UploadExpenseFileCommand.Files)));
    }
}
