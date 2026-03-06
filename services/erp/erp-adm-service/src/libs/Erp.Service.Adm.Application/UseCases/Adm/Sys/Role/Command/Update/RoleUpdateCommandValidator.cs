using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class RoleUpdateCommandValidator : AbstractValidator<RoleUpdateCommand>
{
    public RoleUpdateCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage($"{nameof(RoleUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName).NotEmpty().WithMessage($"{nameof(RoleUpdateCommand.ShortName)} is required");
        RuleFor(x => x.FullName).NotEmpty().WithMessage($"{nameof(RoleUpdateCommand.FullName)} is required");
    }
}
