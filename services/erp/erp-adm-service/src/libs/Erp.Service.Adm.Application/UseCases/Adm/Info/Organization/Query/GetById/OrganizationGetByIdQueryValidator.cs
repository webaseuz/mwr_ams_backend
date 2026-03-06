using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class OrganizationGetByIdQueryValidator : AbstractValidator<OrganizationGetByIdQuery>
{
    public OrganizationGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(OrganizationGetByIdQuery.Id)} is required");
    }
}
