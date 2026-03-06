using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class ContractorCreateCommandValidator : AbstractValidator<ContractorCreateCommand>
{
    public ContractorCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(ContractorCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(ContractorCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(ContractorCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(ContractorCreateCommand.FullName)} max length is 250");
        RuleFor(x => x.Inn)
            .NotEmpty()
            .WithMessage($"{nameof(ContractorCreateCommand.Inn)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(ContractorCreateCommand.Inn)} max length is 250");
    }
}
