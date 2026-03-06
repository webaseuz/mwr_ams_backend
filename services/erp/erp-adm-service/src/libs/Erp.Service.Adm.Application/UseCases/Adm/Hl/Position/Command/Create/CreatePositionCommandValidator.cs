using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CreatePositionCommandValidator : AbstractValidator<PositionCreateCommand>
{
    public CreatePositionCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(PositionCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(PositionCreateCommand.ShortName)} max length is 250");

        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(PositionCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(PositionCreateCommand.FullName)} max length is 250");

        RuleFor(x => x.Code)
            .MaximumLength(50)
            .WithMessage($"{nameof(PositionCreateCommand.Code)} max length is 50");
    }
}
