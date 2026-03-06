using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UpdatePositionCommandValidator : AbstractValidator<PositionUpdateCommand>
{
    public UpdatePositionCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(PositionUpdateCommand.Id)} is required");

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(PositionUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(PositionUpdateCommand.ShortName)} max length is 250");

        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(PositionUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(PositionUpdateCommand.FullName)} max length is 250");

        RuleFor(x => x.Code)
            .MaximumLength(50)
            .WithMessage($"{nameof(PositionUpdateCommand.Code)} max length is 50");
    }
}
