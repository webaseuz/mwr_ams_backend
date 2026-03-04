using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportModelGetByIdQueryValidator : AbstractValidator<TransportModelGetByIdQuery>
{
    public TransportModelGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(TransportModelGetByIdQuery.Id)} is required");
    }
}
