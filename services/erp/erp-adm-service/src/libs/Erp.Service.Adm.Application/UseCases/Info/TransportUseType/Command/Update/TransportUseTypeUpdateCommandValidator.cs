using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportUseTypeUpdateCommandValidator : AbstractValidator<TransportUseTypeUpdateCommand>
{
    public TransportUseTypeUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(TransportUseTypeUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(TransportUseTypeUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TransportUseTypeUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(TransportUseTypeUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TransportUseTypeUpdateCommand.FullName)} max length is 250");
    }
}
