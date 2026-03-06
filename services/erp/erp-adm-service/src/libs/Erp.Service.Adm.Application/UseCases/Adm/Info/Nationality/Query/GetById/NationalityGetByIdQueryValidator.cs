using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class NationalityGetByIdQueryValidator : AbstractValidator<NationalityGetByIdQuery>
{
    public NationalityGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(NationalityGetByIdQuery.Id)} is required");
    }
}
