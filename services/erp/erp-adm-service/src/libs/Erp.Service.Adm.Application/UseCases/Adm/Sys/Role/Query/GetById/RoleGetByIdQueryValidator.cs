using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class RoleGetByIdQueryValidator : AbstractValidator<RoleGetByIdQuery>
{
    public RoleGetByIdQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage($"{nameof(RoleGetByIdQuery.Id)} is required");
    }
}
