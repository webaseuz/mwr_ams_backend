using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class DistrictCreateCommandValidator : AbstractValidator<DistrictCreateCommand>
{
    public DistrictCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(DistrictCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(DistrictCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(DistrictCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(DistrictCreateCommand.FullName)} max length is 250");
    }
}
