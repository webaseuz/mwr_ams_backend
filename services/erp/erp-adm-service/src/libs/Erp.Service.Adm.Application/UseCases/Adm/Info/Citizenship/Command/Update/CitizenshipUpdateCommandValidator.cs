using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CitizenshipUpdateCommandValidator : AbstractValidator<CitizenshipUpdateCommand>
{
    public CitizenshipUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(CitizenshipUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(CitizenshipUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CitizenshipUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(CitizenshipUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CitizenshipUpdateCommand.FullName)} max length is 250");
    }
}
