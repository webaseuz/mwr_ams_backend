using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class PresentNotificationGetByIdQueryValidator : AbstractValidator<PresentNotificationGetByIdQuery>
{
    public PresentNotificationGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(PresentNotificationGetByIdQuery.Id)} is required");
    }
}
