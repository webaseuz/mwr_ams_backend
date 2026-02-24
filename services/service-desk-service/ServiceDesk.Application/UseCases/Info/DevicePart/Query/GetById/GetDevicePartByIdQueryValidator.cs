using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class GetDevicePartByIdQueryValidator :
    AbstractValidator<GetDevicePartByIdQuery>
{
    public GetDevicePartByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetDevicePartByIdQuery.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetDevicePartByIdQuery.Id), 1, int.MaxValue));
    }
}
