using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class GetDepartmentByIdQueryValidator : AbstractValidator<DepartmentGetByIdQuery>
{
    public GetDepartmentByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(DepartmentGetByIdQuery.Id)} is required");
    }
}
