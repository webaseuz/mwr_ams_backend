using AutoPark.Application.UseCases.Persons;
using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Drivers;

public class UpdateDriverCommandValidator :
    AbstractValidator<UpdateDriverCommand>
{
    public UpdateDriverCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateDriverCommand.Id)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDriverCommand.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDriverCommand.Id), 1, int.MaxValue));

        RuleFor(x => x.BranchId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateDriverCommand.BranchId)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDriverCommand.BranchId), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDriverCommand.BranchId), 1, int.MaxValue));

        RuleFor(x => x.Person)
            .NotNull()
            .SetValidator(new UpdatePersonCommandValidator());
    }
}
