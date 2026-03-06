using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class GetTransportByIdQueryValidator : AbstractValidator<TransportGetByIdQuery>
{
    public GetTransportByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0).WithMessage($"{nameof(TransportGetByIdQuery.Id)} is required");
    }
}
