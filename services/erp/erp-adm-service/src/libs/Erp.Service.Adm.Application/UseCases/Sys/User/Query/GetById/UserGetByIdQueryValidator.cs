using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UserGetByIdQueryValidator : AbstractValidator<UserGetByIdQuery>
{
    public UserGetByIdQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage($"{nameof(UserGetByIdQuery.Id)} is required");
    }
}
