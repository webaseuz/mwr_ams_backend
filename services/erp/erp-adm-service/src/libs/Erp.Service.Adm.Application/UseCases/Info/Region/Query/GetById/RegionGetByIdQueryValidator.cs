using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class RegionGetByIdQueryValidator : AbstractValidator<RegionGetByIdQuery>
{
    public RegionGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(RegionGetByIdQuery.Id)} is required");
    }
}
