using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Departments;

public class CreateDepatmentCommandValidator :
    AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepatmentCommandValidator()
    {
        RuleFor(x => x.OrderCode)
            .MaximumLength(3)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDepartmentCommand.OrderCode), 1, 3));

        RuleFor(x => x.Code)
            .MaximumLength(3)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDepartmentCommand.Code), 1, 3));

        RuleFor(x => x.ShortName)
                    .NotEmpty()
                    .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateDepartmentCommand.ShortName)))
                    .MaximumLength(250)
                    .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDepartmentCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
                    .NotEmpty()
                    .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateDepartmentCommand.FullName)))
                    .MaximumLength(250)
                    .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDepartmentCommand.FullName), 1, 250));

    }
}