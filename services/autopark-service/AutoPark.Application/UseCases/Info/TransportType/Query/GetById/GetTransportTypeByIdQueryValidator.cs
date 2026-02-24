using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TransportTypes;

public class GetTransportTypeByIdQueryValidator :
    AbstractValidator<GetTransportTypeByIdQuery>
{
    public GetTransportTypeByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetTransportTypeByIdQuery.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetTransportTypeByIdQuery.Id), 1, int.MaxValue));
    }
}
