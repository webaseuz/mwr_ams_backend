using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UpdateDriverCommandValidator : AbstractValidator<DriverUpdateCommand>
{
    public UpdateDriverCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(DriverUpdateCommand.Id)} is required");

        RuleFor(x => x.BranchId)
            .GreaterThan(0)
            .WithMessage($"{nameof(DriverUpdateCommand.BranchId)} is required");

        RuleFor(x => x.Person)
            .NotNull()
            .WithMessage($"{nameof(DriverUpdateCommand.Person)} is required");
    }
}
