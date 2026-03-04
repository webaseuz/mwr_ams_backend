using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class ContractorUpdateCommandValidator : AbstractValidator<ContractorUpdateCommand>
{
    public ContractorUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0L)
            .WithMessage($"{nameof(ContractorUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(ContractorUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(ContractorUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(ContractorUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(ContractorUpdateCommand.FullName)} max length is 250");
        RuleFor(x => x.Inn)
            .NotEmpty()
            .WithMessage($"{nameof(ContractorUpdateCommand.Inn)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(ContractorUpdateCommand.Inn)} max length is 250");
    }
}
