using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class GetDriverDocumentByIdQueryValidator : AbstractValidator<DriverDocumentGetByIdQuery>
{
    public GetDriverDocumentByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(DriverDocumentGetByIdQuery.Id)} is required");
    }
}
