using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Branches;

public class UpdateBranchCommandValidator :
    AbstractValidator<UpdateBranchCommand>
{
    public UpdateBranchCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateBranchCommand.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateBranchCommand.Id), 1, int.MaxValue));

        RuleFor(x => x.UniqueCode)
            .MinimumLength(3)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateBranchCommand.UniqueCode), 1, 3));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateBranchCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateBranchCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateBranchCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateBranchCommand.FullName), 1, 250));

        RuleFor(x => x.Address)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateBranchCommand.Address)))
            .MaximumLength(500)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateBranchCommand.Address), 5, 500));

        RuleFor(x => x.Longitude)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateBranchCommand.Longitude)))
            .Must(x => double.TryParse(x, out _))
            .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(UpdateBranchCommand.Longitude)));

        RuleFor(x => x.Latitude)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateBranchCommand.Latitude)))
            .Must(x => double.TryParse(x, out _))
            .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(UpdateBranchCommand.Latitude)));
    }
}
