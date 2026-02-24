using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TransportBrands;

public class GetTransportBrandByIdQueryValidator :
    AbstractValidator<GetTransportBrandByIdQuery>
{
    public GetTransportBrandByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetTransportBrandByIdQuery.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetTransportBrandByIdQuery.Id), 1, int.MaxValue));
    }
}
