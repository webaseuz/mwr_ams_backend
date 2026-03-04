using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportTypeGetByIdQueryValidator : AbstractValidator<TransportTypeGetByIdQuery>
{
    public TransportTypeGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(TransportTypeGetByIdQuery.Id)} is required");
    }
}
