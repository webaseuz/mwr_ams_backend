using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class GetTransportUseTypeByIdQueryValidator :
    AbstractValidator<GetTransportUseTypeByIdQuery>
{
    public GetTransportUseTypeByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetTransportUseTypeByIdQuery.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetTransportUseTypeByIdQuery.Id), 1, int.MaxValue));
    }
}
