using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class GetFuelCardByIdQueryValidator : AbstractValidator<FuelCardGetByIdQuery>
{
    public GetFuelCardByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(FuelCardGetByIdQuery.Id)} is required");
    }
}
