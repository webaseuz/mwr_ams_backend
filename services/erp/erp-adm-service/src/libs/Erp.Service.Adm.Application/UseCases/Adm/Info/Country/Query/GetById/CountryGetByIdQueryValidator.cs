using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CountryGetByIdQueryValidator : AbstractValidator<CountryGetByIdQuery>
{
    public CountryGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(CountryGetByIdQuery.Id)} is required");
    }
}
