using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TireSizeUpdateCommandValidator : AbstractValidator<TireSizeUpdateCommand>
{
    public TireSizeUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(TireSizeUpdateCommand.Id)} is required");
    }
}
