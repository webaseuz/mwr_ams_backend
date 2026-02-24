using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TireSizes;

public class GetTireSizeByIdQueryValidator :
    AbstractValidator<GetTireSizeByIdQuery>
{
    public GetTireSizeByIdQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotNull()
           .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GetTireSizeByIdQuery.Id)))
           .GreaterThan(0)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetTireSizeByIdQuery.Id), 1, int.MaxValue))
           .LessThan(int.MaxValue)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetTireSizeByIdQuery.Id), 1, int.MaxValue));
    }
}
