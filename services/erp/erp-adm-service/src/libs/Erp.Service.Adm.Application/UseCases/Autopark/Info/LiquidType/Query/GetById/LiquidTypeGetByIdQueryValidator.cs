using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class LiquidTypeGetByIdQueryValidator : AbstractValidator<LiquidTypeGetByIdQuery>
{
    public LiquidTypeGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(LiquidTypeGetByIdQuery.Id)} is required");
    }
}
