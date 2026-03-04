using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TireModelCreateCommandValidator : AbstractValidator<TireModelCreateCommand>
{
    public TireModelCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(TireModelCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TireModelCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(TireModelCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TireModelCreateCommand.FullName)} max length is 250");
    }
}
