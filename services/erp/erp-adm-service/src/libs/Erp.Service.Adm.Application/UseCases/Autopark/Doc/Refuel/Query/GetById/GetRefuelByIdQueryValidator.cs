using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases.Document.Refuel;

public class GetRefuelByIdQueryValidator : AbstractValidator<RefuelGetByIdQuery>
{
    public GetRefuelByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage($"{nameof(RefuelGetByIdQuery.Id)} is required")
            .GreaterThan(0).WithMessage($"{nameof(RefuelGetByIdQuery.Id)} must be greater than 0");
    }
}
