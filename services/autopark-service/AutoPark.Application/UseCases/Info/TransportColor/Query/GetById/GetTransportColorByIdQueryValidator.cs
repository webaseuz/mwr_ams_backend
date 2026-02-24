using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TransportColors;

public class GetTransportColorByIdQueryValidator :
    AbstractValidator<GetTransportColorByIdQuery>
{
    public GetTransportColorByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetTransportColorByIdQuery.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetTransportColorByIdQuery.Id), 1, int.MaxValue));
    }
}
