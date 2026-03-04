using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class RoleCreateCommandValidator : AbstractValidator<RoleCreateCommand>
{
    public RoleCreateCommandValidator()
    {
        RuleFor(x => x.ShortName).NotEmpty().WithMessage($"{nameof(RoleCreateCommand.ShortName)} is required");
        RuleFor(x => x.FullName).NotEmpty().WithMessage($"{nameof(RoleCreateCommand.FullName)} is required");
    }
}
