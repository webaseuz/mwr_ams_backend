using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Nationalities;

public class UpdateNationalityCommandValidator :
    AbstractValidator<UpdateNationalityCommand>
{
    public UpdateNationalityCommandValidator()
    {
                RuleFor(x => x.Id)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateNationalityCommand.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateNationalityCommand.Id), 1, int.MaxValue));

        RuleFor(x => x.WbCode)
           .MinimumLength(3)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateNationalityCommand.WbCode), 1, 3));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateNationalityCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateNationalityCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateNationalityCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateNationalityCommand.FullName), 1, 250));
    }
}
