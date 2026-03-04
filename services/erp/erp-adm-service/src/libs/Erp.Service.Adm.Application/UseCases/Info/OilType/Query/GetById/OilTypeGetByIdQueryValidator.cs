using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class OilTypeGetByIdQueryValidator : AbstractValidator<OilTypeGetByIdQuery>
{
    public OilTypeGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(OilTypeGetByIdQuery.Id)} is required");
    }
}
