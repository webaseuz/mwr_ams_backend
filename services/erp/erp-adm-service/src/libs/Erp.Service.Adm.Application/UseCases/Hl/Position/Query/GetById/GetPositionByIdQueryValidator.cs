using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class GetPositionByIdQueryValidator : AbstractValidator<PositionGetByIdQuery>
{
    public GetPositionByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(PositionGetByIdQuery.Id)} is required");
    }
}
