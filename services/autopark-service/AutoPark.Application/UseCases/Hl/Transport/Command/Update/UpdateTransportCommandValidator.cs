using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AutoPark.Application.UseCases.Transports;

public class UpdateTransportCommandValidator :
    AbstractValidator<UpdateTransportCommand>
{
    public UpdateTransportCommandValidator()
    {
        RuleFor(x => x.Id)
                .NotNull()
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateTransportCommand.Id), 1, int.MaxValue));

        RuleFor(x => x.BranchId)
                .NotNull()
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateTransportCommand.BranchId), 1, int.MaxValue));

        RuleFor(x => x.TransportModelId)
                .NotNull()
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateTransportCommand.TransportModelId), 1, int.MaxValue));

        RuleFor(x => x.TransportUseTypeId)
                .NotNull()
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateTransportCommand.TransportUseTypeId), 1, int.MaxValue));

        RuleFor(x => x.TransportBrandId)
                .NotNull()
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateTransportCommand.TransportBrandId), 1, int.MaxValue));

        RuleFor(x => x.TransportColorId)
                .NotNull()
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateTransportCommand.TransportColorId), 1, int.MaxValue));

        RuleFor(x => x.ManufacturedAt)
                .NotNull()
                .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportCommand.ManufacturedAt)));

        RuleFor(x => x.PurchasedAt)
                .NotNull()
                .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportCommand.PurchasedAt)));

        RuleFor(x => x.StateCode)
                .NotEmpty()
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateTransportCommand.BranchId), 1, 5));

        RuleFor(x => x.StateNumber)
                .NotEmpty()
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportCommand.StateNumber), 1, 50))
                .Must(value => Regex.IsMatch(value ?? "", @"^\s*\d{3}\s*[A-Za-z]{3}\s*$"))
                .Failure(ClientValidationExceptionHelper.Wrap($"""
                                                                Неверный формат ({nameof(CreateTransportCommand.StateNumber)}: "value")
                                                                Например, "123 AAA"
                                                                """, ErrorCode.CLIENT_INVALID_PROPERTY_FORMAT));

        RuleFor(x => x.VinNumber)
                .NotEmpty()
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateTransportCommand.VinNumber), 1, 50));

        RuleFor(x => x.PurchasedAmount)
                .NotNull()
                .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportCommand.PurchasedAmount)));

        RuleFor(x => x.AmortizationPeriod)
                .NotNull()
                .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportCommand.AmortizationPeriod)));
    }
}
