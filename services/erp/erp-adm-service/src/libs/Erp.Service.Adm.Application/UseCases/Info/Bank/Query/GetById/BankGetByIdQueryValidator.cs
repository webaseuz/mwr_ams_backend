using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class BankGetByIdQueryValidator : AbstractValidator<BankGetByIdQuery>
{
    public BankGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(BankGetByIdQuery.Id)} is required");
    }
}
