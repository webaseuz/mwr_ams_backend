using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UpdateFuelCardCommandValidator : AbstractValidator<FuelCardUpdateCommand>
{
    public UpdateFuelCardCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(FuelCardUpdateCommand.Id)} is required");

        RuleFor(x => x.PlasticCardTypeId)
            .GreaterThan(0)
            .WithMessage($"{nameof(FuelCardUpdateCommand.PlasticCardTypeId)} is required");

        RuleFor(x => x.CardNumber)
            .NotEmpty()
            .WithMessage($"{nameof(FuelCardUpdateCommand.CardNumber)} is required");

        RuleFor(x => x.ExpireAt)
            .NotEmpty()
            .WithMessage($"{nameof(FuelCardUpdateCommand.ExpireAt)} is required");
    }
}
