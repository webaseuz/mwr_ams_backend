using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class GetDriverByIdQueryValidator : AbstractValidator<DriverGetByIdQuery>
{
    public GetDriverByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(DriverGetByIdQuery.Id)} is required");
    }
}
