using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportBrandGetByIdQueryValidator : AbstractValidator<TransportBrandGetByIdQuery>
{
    public TransportBrandGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(TransportBrandGetByIdQuery.Id)} is required");
    }
}
