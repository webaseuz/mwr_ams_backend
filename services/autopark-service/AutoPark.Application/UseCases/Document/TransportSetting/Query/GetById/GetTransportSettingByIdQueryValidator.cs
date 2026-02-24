using AutoPark.Application.UseCases.TransportSettings;
using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Banks;

public class GetTransportSettingByIdQueryValidator :
    AbstractValidator<GetTransportSettingByIdQuery>
{
    public GetTransportSettingByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetTransportSettingByIdQuery.Id), 1, int.MaxValue));
    }
}