using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Transports;

public class GetTransportByIdQueryValidator :
    AbstractValidator<GetTransportByIdQuery>
{
    public GetTransportByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetTransportByIdQuery.Id), 1, int.MaxValue));
    }
}
