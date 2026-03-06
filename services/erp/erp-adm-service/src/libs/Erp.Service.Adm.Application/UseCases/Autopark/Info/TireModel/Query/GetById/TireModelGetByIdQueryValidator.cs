using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TireModelGetByIdQueryValidator : AbstractValidator<TireModelGetByIdQuery>
{
    public TireModelGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(TireModelGetByIdQuery.Id)} is required");
    }
}
