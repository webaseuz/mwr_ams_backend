using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class NationalityUpdateCommandValidator : AbstractValidator<NationalityUpdateCommand>
{
    public NationalityUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(NationalityUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(NationalityUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(NationalityUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(NationalityUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(NationalityUpdateCommand.FullName)} max length is 250");
    }
}
