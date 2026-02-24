using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;
using ServiceDesk.Application.UseCases.DeviceModels;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

public class CreateApplicationPurposeCommandValidator :
    AbstractValidator<CreateApplicationPurposeCommand>
{
    public CreateApplicationPurposeCommandValidator()
    {
        RuleFor(x => x.OrderCode)
            .MinimumLength(3)
            .MaximumLength(5)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateApplicationPurposeCommand.OrderCode), 3, 6));

        RuleFor(x => x.DeviceTypeId)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateApplicationPurposeCommand.DeviceTypeId), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateApplicationPurposeCommand.DeviceTypeId), 1, int.MaxValue));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateApplicationPurposeCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateApplicationPurposeCommand.FullName), 1, 500));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateApplicationPurposeCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateApplicationPurposeCommand.ShortName), 1, 250));
    }
}
