using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class DistrictGetByIdQueryValidator : AbstractValidator<DistrictGetByIdQuery>
{
    public DistrictGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(DistrictGetByIdQuery.Id)} is required");
    }
}
