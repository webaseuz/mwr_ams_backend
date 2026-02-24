using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class CreateServiceApplicationCommandValidator :
    AbstractValidator<CreateServiceApplicationCommand>
{
	public CreateServiceApplicationCommandValidator()
	{
        RuleFor(x => x.BranchId)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateServiceApplicationCommand.BranchId)));

        RuleFor(x => x.DeviceId)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateServiceApplicationCommand.DeviceId)));

        RuleFor(x => x.ExecutorTypeId)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateServiceApplicationCommand.ExecutorTypeId)));

        RuleFor(x => x.ServiceContractorId)
            .GreaterThan(0)
            .When(x => x.ServiceContractorId.HasValue)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateServiceApplicationCommand.ServiceContractorId)));

        RuleFor(x => x.ResponsiblePersonId)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateServiceApplicationCommand.ResponsiblePersonId)));

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches(@"^\+?\d{9,15}$")
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateServiceApplicationCommand.PhoneNumber)));
    }
}
