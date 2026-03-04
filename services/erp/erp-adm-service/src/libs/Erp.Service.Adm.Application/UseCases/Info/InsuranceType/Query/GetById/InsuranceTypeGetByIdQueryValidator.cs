using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class InsuranceTypeGetByIdQueryValidator : AbstractValidator<InsuranceTypeGetByIdQuery>
{
    public InsuranceTypeGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(InsuranceTypeGetByIdQuery.Id)} is required");
    }
}
