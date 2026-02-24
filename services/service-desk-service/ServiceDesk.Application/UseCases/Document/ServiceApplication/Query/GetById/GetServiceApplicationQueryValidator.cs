using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class GetServiceApplicationQueryValidator : 
    AbstractValidator<GetServiceApplicationByIdQuery>
{
	public GetServiceApplicationQueryValidator()
	{
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GetServiceApplicationByIdQuery.Id)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetServiceApplicationByIdQuery.Id), 1, int.MaxValue))
            .LessThan(long.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetServiceApplicationByIdQuery.Id), 1, int.MaxValue));
    }
}
