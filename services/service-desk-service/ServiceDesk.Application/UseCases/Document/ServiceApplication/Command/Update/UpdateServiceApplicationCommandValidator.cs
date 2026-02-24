using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class UpdateServiceApplicationCommandValidator:
    AbstractValidator<UpdateServiceApplicationCommand>
{
	public UpdateServiceApplicationCommandValidator()
	{
         RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateServiceApplicationCommand.Id)));

        RuleFor(x => x.DocNumber)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateServiceApplicationCommand.DocNumber)));

        RuleFor(x => x.BranchId)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateServiceApplicationCommand.BranchId)));

        RuleFor(x => x.DeviceId)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateServiceApplicationCommand.DeviceId)));

        RuleFor(x => x.ExecutorTypeId)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateServiceApplicationCommand.ExecutorTypeId)));

        RuleFor(x => x.ServiceContractorId)
            .GreaterThan(0)
            .When(x => x.ServiceContractorId.HasValue)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateServiceApplicationCommand.ServiceContractorId)));

        RuleFor(x => x.ResponsiblePersonId)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateServiceApplicationCommand.ResponsiblePersonId)));

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches(@"^\+?\d{9,15}$")
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateServiceApplicationCommand.PhoneNumber)));
    }
}
