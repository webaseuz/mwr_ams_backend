using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UpdateDepartmentCommandValidator : AbstractValidator<DepartmentUpdateCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(DepartmentUpdateCommand.Id)} is required");

        RuleFor(x => x.BranchId)
            .GreaterThan(0)
            .WithMessage($"{nameof(DepartmentUpdateCommand.BranchId)} is required");

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(DepartmentUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(DepartmentUpdateCommand.ShortName)} max length is 250");

        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(DepartmentUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(DepartmentUpdateCommand.FullName)} max length is 250");

        RuleFor(x => x.Code)
            .MaximumLength(50)
            .WithMessage($"{nameof(DepartmentUpdateCommand.Code)} max length is 50");
    }
}
