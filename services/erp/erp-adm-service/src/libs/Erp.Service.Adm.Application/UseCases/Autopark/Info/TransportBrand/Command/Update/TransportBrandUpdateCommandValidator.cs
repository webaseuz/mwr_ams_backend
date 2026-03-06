using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportBrandUpdateCommandValidator : AbstractValidator<TransportBrandUpdateCommand>
{
    public TransportBrandUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(TransportBrandUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(TransportBrandUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TransportBrandUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(TransportBrandUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TransportBrandUpdateCommand.FullName)} max length is 250");
    }
}
