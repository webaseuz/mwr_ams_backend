using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class GetLiquidTypeByIdValidator :
       AbstractValidator<GetLiquidTypeByIdQuery>
{
    public GetLiquidTypeByIdValidator()
    {
        RuleFor(x => x.Id)
         .NotNull()
         .GreaterThan(0)
         .LessThan(int.MaxValue)
         .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetLiquidTypeByIdQuery.Id), 1, int.MaxValue));
    }
}
