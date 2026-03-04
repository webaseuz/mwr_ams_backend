using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CreateNotificationCommandValidator : AbstractValidator<NotificationCreateCommand>
{
    public CreateNotificationCommandValidator()
    {
    }
}
