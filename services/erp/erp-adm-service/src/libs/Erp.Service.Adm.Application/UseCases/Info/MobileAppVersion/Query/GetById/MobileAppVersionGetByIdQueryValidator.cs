using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class MobileAppVersionGetByIdQueryValidator : AbstractValidator<MobileAppVersionGetByIdQuery>
{
    public MobileAppVersionGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage($"{nameof(MobileAppVersionGetByIdQuery.Id)} is required");
    }
}
