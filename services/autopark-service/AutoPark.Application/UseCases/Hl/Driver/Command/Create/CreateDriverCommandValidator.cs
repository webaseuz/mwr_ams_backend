using AutoPark.Application.UseCases.Persons;
using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Drivers;

public class CreateDriverCommandValidator :
    AbstractValidator<CreateDriverCommand>
{
    public CreateDriverCommandValidator()
    {
        RuleFor(x => x.BranchId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateDriverCommand.BranchId)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDriverCommand.BranchId), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDriverCommand.BranchId), 1, int.MaxValue));

        RuleFor(x => x.Person)
            .NotNull()
            .SetValidator(new CreatePersonCommandValidator());
    }
}
