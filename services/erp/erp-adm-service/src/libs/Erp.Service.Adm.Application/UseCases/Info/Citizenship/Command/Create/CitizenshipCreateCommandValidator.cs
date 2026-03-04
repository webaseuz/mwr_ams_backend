using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CitizenshipCreateCommandValidator : AbstractValidator<CitizenshipCreateCommand>
{
    public CitizenshipCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(CitizenshipCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CitizenshipCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(CitizenshipCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CitizenshipCreateCommand.FullName)} max length is 250");
    }
}
