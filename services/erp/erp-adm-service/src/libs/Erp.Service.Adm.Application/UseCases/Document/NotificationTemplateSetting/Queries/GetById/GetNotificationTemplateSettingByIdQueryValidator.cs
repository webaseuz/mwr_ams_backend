using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class GetNotificationTemplateSettingByIdQueryValidator :
    AbstractValidator<GetNotificationTemplateSettingByIdQuery>
{
    public GetNotificationTemplateSettingByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(GetNotificationTemplateSettingByIdQuery.Id)} must be greater than 0");
    }
}
