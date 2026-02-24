using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Devices;

public class GetDeviceByIdQueryValidator :
    AbstractValidator<GetDeviceByIdQuery>
{
    public GetDeviceByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetDeviceByIdQuery.Id), 1, int.MaxValue));
    }
}