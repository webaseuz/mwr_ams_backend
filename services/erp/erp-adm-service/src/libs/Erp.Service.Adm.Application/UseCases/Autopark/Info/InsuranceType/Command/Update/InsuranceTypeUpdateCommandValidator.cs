using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class InsuranceTypeUpdateCommandValidator : AbstractValidator<InsuranceTypeUpdateCommand>
{
    public InsuranceTypeUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(InsuranceTypeUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(InsuranceTypeUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(InsuranceTypeUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(InsuranceTypeUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(InsuranceTypeUpdateCommand.FullName)} max length is 250");
    }
}
