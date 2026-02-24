using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class GetDeviceTypeByIdQueryValidator :
    AbstractValidator<GetDeviceTypeByIdQuery>
{
    public GetDeviceTypeByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetDeviceTypeByIdQuery.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetDeviceTypeByIdQuery.Id), 1, int.MaxValue));
    }
}
