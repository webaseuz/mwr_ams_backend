using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class GetSpareMovementQueryValidator : 
    AbstractValidator<GetSpareMovementByIdQuery>
{
	public GetSpareMovementQueryValidator()
	{
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GetSpareMovementByIdQuery.Id)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetSpareMovementByIdQuery.Id), 1, int.MaxValue))
            .LessThan(long.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetSpareMovementByIdQuery.Id), 1, int.MaxValue));
    }
}
