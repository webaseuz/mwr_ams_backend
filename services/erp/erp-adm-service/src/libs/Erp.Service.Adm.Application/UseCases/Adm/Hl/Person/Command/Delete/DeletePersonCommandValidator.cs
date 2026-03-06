using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class DeletePersonCommandValidator : AbstractValidator<PersonDeleteCommand>
{
    public DeletePersonCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage($"{nameof(PersonDeleteCommand.Id)} is required");
    }
}
