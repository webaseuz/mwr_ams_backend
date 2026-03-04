using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportTypeUpdateCommandValidator : AbstractValidator<TransportTypeUpdateCommand>
{
    public TransportTypeUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(TransportTypeUpdateCommand.Id)} is required");

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(TransportTypeUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TransportTypeUpdateCommand.ShortName)} max length is 250");

        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(TransportTypeUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TransportTypeUpdateCommand.FullName)} max length is 250");
    }
}
