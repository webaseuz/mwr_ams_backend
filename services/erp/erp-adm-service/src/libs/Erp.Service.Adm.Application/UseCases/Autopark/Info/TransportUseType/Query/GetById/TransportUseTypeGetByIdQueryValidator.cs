using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportUseTypeGetByIdQueryValidator : AbstractValidator<TransportUseTypeGetByIdQuery>
{
    public TransportUseTypeGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(TransportUseTypeGetByIdQuery.Id)} is required");
    }
}
