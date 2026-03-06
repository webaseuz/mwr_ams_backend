using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class GetPersonByIdQueryValidator : AbstractValidator<PersonGetByIdQuery>
{
    public GetPersonByIdQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage($"{nameof(PersonGetByIdQuery.Id)} is required");
    }
}
