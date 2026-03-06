using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class InsuranceTypeCreateCommandValidator : AbstractValidator<InsuranceTypeCreateCommand>
{
    public InsuranceTypeCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(InsuranceTypeCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(InsuranceTypeCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(InsuranceTypeCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(InsuranceTypeCreateCommand.FullName)} max length is 250");
    }
}
