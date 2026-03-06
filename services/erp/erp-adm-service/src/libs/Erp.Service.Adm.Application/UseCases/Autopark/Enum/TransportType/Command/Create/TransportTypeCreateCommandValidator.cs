using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportTypeCreateCommandValidator : AbstractValidator<TransportTypeCreateCommand>
{
    public TransportTypeCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(TransportTypeCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TransportTypeCreateCommand.ShortName)} max length is 250");

        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(TransportTypeCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TransportTypeCreateCommand.FullName)} max length is 250");
    }
}
