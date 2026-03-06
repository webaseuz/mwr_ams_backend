using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CitizenshipGetByIdQueryValidator : AbstractValidator<CitizenshipGetByIdQuery>
{
    public CitizenshipGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(CitizenshipGetByIdQuery.Id)} is required");
    }
}
