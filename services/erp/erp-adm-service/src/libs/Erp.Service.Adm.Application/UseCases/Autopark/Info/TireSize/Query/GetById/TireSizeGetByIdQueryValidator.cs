using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TireSizeGetByIdQueryValidator : AbstractValidator<TireSizeGetByIdQuery>
{
    public TireSizeGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(TireSizeGetByIdQuery.Id)} is required");
    }
}
