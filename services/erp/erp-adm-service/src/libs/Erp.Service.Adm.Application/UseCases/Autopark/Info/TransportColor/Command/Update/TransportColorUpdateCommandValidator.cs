using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportColorUpdateCommandValidator : AbstractValidator<TransportColorUpdateCommand>
{
    public TransportColorUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(TransportColorUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(TransportColorUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TransportColorUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(TransportColorUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TransportColorUpdateCommand.FullName)} max length is 250");
    }
}
