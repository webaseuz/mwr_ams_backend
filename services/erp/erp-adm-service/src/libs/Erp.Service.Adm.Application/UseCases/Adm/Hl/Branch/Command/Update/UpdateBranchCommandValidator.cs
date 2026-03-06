using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UpdateBranchCommandValidator : AbstractValidator<BranchUpdateCommand>
{
    public UpdateBranchCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(BranchUpdateCommand.Id)} is required");

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(BranchUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(BranchUpdateCommand.ShortName)} max length is 250");

        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(BranchUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(BranchUpdateCommand.FullName)} max length is 250");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage($"{nameof(BranchUpdateCommand.Address)} is required")
            .MaximumLength(500)
            .WithMessage($"{nameof(BranchUpdateCommand.Address)} max length is 500");

        RuleFor(x => x.Longitude)
            .NotEmpty()
            .WithMessage($"{nameof(BranchUpdateCommand.Longitude)} is required")
            .Must(x => double.TryParse(x, out _))
            .WithMessage($"{nameof(BranchUpdateCommand.Longitude)} invalid format");

        RuleFor(x => x.Latitude)
            .NotEmpty()
            .WithMessage($"{nameof(BranchUpdateCommand.Latitude)} is required")
            .Must(x => double.TryParse(x, out _))
            .WithMessage($"{nameof(BranchUpdateCommand.Latitude)} invalid format");
    }
}
