using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Branches;

public class CreateBranchCommandValidator :
    AbstractValidator<CreateBranchCommand>
{
    public CreateBranchCommandValidator()
    {
        RuleFor(x => x.UniqueCode)
            .MaximumLength(3)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateBranchCommand.UniqueCode), 1, 3));

        RuleFor(x => x.ShortName)
                    .NotEmpty()
                    .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateBranchCommand.ShortName)))
                    .MaximumLength(250)
                    .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateBranchCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
                    .NotEmpty()
                    .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateBranchCommand.FullName)))
                    .MaximumLength(250)
                    .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateBranchCommand.FullName), 1, 250));

        RuleFor(x => x.Address)
                    .NotEmpty()
                    .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateBranchCommand.Address)))
                    .MaximumLength(500)
                    .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateBranchCommand.Address), 5, 500));

        RuleFor(x => x.Longitude)
                    .NotEmpty()
                    .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateBranchCommand.Longitude)))
                    .Must(x => double.TryParse(x, out _))
                    .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreateBranchCommand.Longitude)));

        RuleFor(x => x.Latitude)
                    .NotEmpty()
                    .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateBranchCommand.Latitude)))
                    .Must(x => double.TryParse(x, out _))
                    .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreateBranchCommand.Latitude)));
    }
}