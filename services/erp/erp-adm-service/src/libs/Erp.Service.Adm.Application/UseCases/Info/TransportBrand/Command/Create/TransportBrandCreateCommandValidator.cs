using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportBrandCreateCommandValidator : AbstractValidator<TransportBrandCreateCommand>
{
    public TransportBrandCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(TransportBrandCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TransportBrandCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(TransportBrandCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TransportBrandCreateCommand.FullName)} max length is 250");
    }
}
