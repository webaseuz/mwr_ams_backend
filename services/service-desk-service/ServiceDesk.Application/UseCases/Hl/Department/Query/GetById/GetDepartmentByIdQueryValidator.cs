using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Departments;

public class GetDepartmentByIdQueryValidator :
    AbstractValidator<GetDepartmentByIdQuery>
{
    public GetDepartmentByIdQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotNull()
           .GreaterThan(0)
           .LessThan(int.MaxValue)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetDepartmentByIdQuery.Id), 1, int.MaxValue));
    }
}
