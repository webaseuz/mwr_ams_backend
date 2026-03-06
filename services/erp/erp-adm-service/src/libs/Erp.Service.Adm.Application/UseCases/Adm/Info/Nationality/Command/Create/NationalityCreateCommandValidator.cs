using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class NationalityCreateCommandValidator : AbstractValidator<NationalityCreateCommand>
{
    public NationalityCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(NationalityCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(NationalityCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(NationalityCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(NationalityCreateCommand.FullName)} max length is 250");
    }
}
