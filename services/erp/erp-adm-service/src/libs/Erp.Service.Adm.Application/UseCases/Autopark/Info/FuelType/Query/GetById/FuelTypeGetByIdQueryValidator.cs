using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class FuelTypeGetByIdQueryValidator : AbstractValidator<FuelTypeGetByIdQuery>
{
    public FuelTypeGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(FuelTypeGetByIdQuery.Id)} is required");
    }
}
