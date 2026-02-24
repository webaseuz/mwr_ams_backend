using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class GetServiceTypeByIdQueryValidator :
    AbstractValidator<GetServiceTypeByIdQuery>
{
    public GetServiceTypeByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetServiceTypeByIdQuery.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetServiceTypeByIdQuery.Id), 1, int.MaxValue));
    }
}
