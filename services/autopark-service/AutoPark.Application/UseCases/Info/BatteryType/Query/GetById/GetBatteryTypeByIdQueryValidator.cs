using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class GetBatteryTypeByIdQueryValidator :
     AbstractValidator<GetBatteryTypeByIdQuery>
{
    public GetBatteryTypeByIdQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotNull()
           .GreaterThan(0)
           .LessThan(int.MaxValue)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetBatteryTypeByIdQuery.Id), 1, int.MaxValue));
    }
}
