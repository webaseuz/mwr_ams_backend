using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class GetNotificationByIdQueryValidator : AbstractValidator<NotificationGetByIdQuery>
{
    public GetNotificationByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(NotificationGetByIdQuery.Id)} is required");
    }
}
