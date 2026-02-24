using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class GetDeviceSpareTypeByIdQueryValidator :
    AbstractValidator<GetDeviceSpareTypeByIdQuery>
{
    public GetDeviceSpareTypeByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetDeviceSpareTypeByIdQuery.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetDeviceSpareTypeByIdQuery.Id), 1, int.MaxValue));
    }
}
