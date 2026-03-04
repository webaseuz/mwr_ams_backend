using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class OrganizationCreateCommandValidator : AbstractValidator<OrganizationCreateCommand>
{
    public OrganizationCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(OrganizationCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(OrganizationCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(OrganizationCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(OrganizationCreateCommand.FullName)} max length is 250");
    }
}
