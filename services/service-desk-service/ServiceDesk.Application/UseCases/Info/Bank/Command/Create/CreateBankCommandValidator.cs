using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Banks;

public class CreateBankCommandValidator :
    AbstractValidator<CreateBankCommand>
{
    public CreateBankCommandValidator()
    {
        RuleFor(x => x.OrderCode)
            .MinimumLength(3)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateBankCommand.OrderCode), 1, 3));

        RuleFor(x => x.BankCode)
            .MaximumLength(5)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateBankCommand.BankCode), 1, 5));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateBankCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateBankCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateBankCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateBankCommand.FullName), 1, 250));
    }
}
