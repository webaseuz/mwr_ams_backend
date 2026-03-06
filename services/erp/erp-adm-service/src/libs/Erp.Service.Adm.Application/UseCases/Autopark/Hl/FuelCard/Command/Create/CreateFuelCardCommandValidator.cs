using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CreateFuelCardCommandValidator : AbstractValidator<FuelCardCreateCommand>
{
    public CreateFuelCardCommandValidator()
    {
        RuleFor(x => x.PlasticCardTypeId)
            .GreaterThan(0)
            .WithMessage($"{nameof(FuelCardCreateCommand.PlasticCardTypeId)} is required");

        RuleFor(x => x.CardNumber)
            .NotEmpty()
            .WithMessage($"{nameof(FuelCardCreateCommand.CardNumber)} is required");

        RuleFor(x => x.ExpireAt)
            .NotEmpty()
            .WithMessage($"{nameof(FuelCardCreateCommand.ExpireAt)} is required");
    }
}
