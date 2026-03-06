using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class ContractorGetByIdQueryValidator : AbstractValidator<ContractorGetByIdQuery>
{
    public ContractorGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0L)
            .WithMessage($"{nameof(ContractorGetByIdQuery.Id)} is required");
    }
}
