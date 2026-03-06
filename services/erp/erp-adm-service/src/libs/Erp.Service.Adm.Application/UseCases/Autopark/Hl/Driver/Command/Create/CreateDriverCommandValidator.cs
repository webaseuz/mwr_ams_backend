using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CreateDriverCommandValidator : AbstractValidator<DriverCreateCommand>
{
    public CreateDriverCommandValidator()
    {
        RuleFor(x => x.BranchId)
            .GreaterThan(0)
            .WithMessage($"{nameof(DriverCreateCommand.BranchId)} is required");

        RuleFor(x => x.Person)
            .NotNull()
            .WithMessage($"{nameof(DriverCreateCommand.Person)} is required");
    }
}
