using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class GetDeviceModelByIdQueryValidator :
    AbstractValidator<GetDeviceModelByIdQuery>
{
    public GetDeviceModelByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetDeviceModelByIdQuery.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetDeviceModelByIdQuery.Id), 1, int.MaxValue));
    }
}
