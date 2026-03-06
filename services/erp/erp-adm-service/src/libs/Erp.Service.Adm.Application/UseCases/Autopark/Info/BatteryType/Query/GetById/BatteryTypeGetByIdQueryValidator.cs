using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class BatteryTypeGetByIdQueryValidator : AbstractValidator<BatteryTypeGetByIdQuery>
{
    public BatteryTypeGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(BatteryTypeGetByIdQuery.Id)} is required");
    }
}
