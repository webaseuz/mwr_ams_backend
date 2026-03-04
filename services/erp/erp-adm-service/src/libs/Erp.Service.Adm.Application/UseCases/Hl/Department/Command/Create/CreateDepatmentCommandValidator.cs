using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CreateDepartmentCommandValidator : AbstractValidator<DepartmentCreateCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(x => x.BranchId)
            .GreaterThan(0)
            .WithMessage($"{nameof(DepartmentCreateCommand.BranchId)} is required");

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(DepartmentCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(DepartmentCreateCommand.ShortName)} max length is 250");

        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(DepartmentCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(DepartmentCreateCommand.FullName)} max length is 250");

        RuleFor(x => x.Code)
            .MaximumLength(50)
            .WithMessage($"{nameof(DepartmentCreateCommand.Code)} max length is 50");
    }
}
