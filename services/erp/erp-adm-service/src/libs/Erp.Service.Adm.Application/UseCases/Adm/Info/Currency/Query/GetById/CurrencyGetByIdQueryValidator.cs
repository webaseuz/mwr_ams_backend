using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CurrencyGetByIdQueryValidator : AbstractValidator<CurrencyGetByIdQuery>
{
    public CurrencyGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(CurrencyGetByIdQuery.Id)} is required");
    }
}
