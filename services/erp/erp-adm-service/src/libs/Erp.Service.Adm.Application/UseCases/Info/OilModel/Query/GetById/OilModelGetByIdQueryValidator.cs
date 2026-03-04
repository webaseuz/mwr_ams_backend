using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class OilModelGetByIdQueryValidator : AbstractValidator<OilModelGetByIdQuery>
{
    public OilModelGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(OilModelGetByIdQuery.Id)} is required");
    }
}
