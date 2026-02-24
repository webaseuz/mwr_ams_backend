using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Expenses;

public class UpdateExpenseCommandValidator :
    AbstractValidator<UpdateExpenseCommand>
{
    public UpdateExpenseCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateExpenseCommand.Id)));

        RuleFor(x => x.DocDate)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateExpenseCommand.DocDate)));

        RuleFor(x => x.DriverId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateExpenseCommand.DriverId)));

        RuleFor(x => x.TransportId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateExpenseCommand.TransportId)));
    }
}