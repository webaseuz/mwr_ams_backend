using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class GetTransportSettingByIdQueryValidator : AbstractValidator<TransportSettingGetByIdQuery>
{
    public GetTransportSettingByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage($"{nameof(TransportSettingGetByIdQuery.Id)} is required")
            .GreaterThan(0).WithMessage($"{nameof(TransportSettingGetByIdQuery.Id)} must be greater than 0");
    }
}
