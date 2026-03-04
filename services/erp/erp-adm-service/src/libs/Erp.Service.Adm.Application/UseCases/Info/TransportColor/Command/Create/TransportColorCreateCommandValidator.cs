using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportColorCreateCommandValidator : AbstractValidator<TransportColorCreateCommand>
{
    public TransportColorCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(TransportColorCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TransportColorCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(TransportColorCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TransportColorCreateCommand.FullName)} max length is 250");
    }
}
