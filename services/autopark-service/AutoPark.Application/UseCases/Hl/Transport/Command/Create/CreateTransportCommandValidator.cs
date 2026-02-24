using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.RegularExpressions;

namespace AutoPark.Application.UseCases.Transports;

public class CreateTransportCommandValidator :
    AbstractValidator<CreateTransportCommand>
{
    public CreateTransportCommandValidator()
    {
        RuleFor(x => x.BranchId)
        .NotNull()
        .GreaterThan(0)
        .LessThan(int.MaxValue)
        .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportCommand.BranchId), 1, int.MaxValue));

        RuleFor(x => x.TransportModelId)
                .NotNull()
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportCommand.TransportModelId), 1, int.MaxValue));

        RuleFor(x => x.TransportUseTypeId)
                .NotNull()
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportCommand.TransportUseTypeId), 1, int.MaxValue));

        RuleFor(x => x.TransportBrandId)
                .NotNull()
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportCommand.TransportBrandId), 1, int.MaxValue));

        RuleFor(x => x.TransportColorId)
                .NotNull()
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportCommand.TransportColorId), 1, int.MaxValue));

        RuleFor(x => x.ManufacturedAt)
                .NotNull()
                .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportCommand.ManufacturedAt)));

        RuleFor(x => x.PurchasedAt)
                .NotNull()
                .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportCommand.PurchasedAt)));   

        RuleFor(x => x.StateCode)
                .NotEmpty()
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportCommand.BranchId), 1, 5));

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
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportCommand.VinNumber), 1, 50));

        RuleFor(x => x.PurchasedAmount)
                .NotNull()
                .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportCommand.PurchasedAmount)));

        RuleFor(x => x.AmortizationPeriod)
                .NotNull()
                .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportCommand.AmortizationPeriod)));

    }
}
