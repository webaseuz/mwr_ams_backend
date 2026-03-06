using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CreateBranchCommandValidator : AbstractValidator<BranchCreateCommand>
{
    public CreateBranchCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(BranchCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(BranchCreateCommand.ShortName)} max length is 250");

        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(BranchCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(BranchCreateCommand.FullName)} max length is 250");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage($"{nameof(BranchCreateCommand.Address)} is required")
            .MaximumLength(500)
            .WithMessage($"{nameof(BranchCreateCommand.Address)} max length is 500");

        RuleFor(x => x.Longitude)
            .NotEmpty()
            .WithMessage($"{nameof(BranchCreateCommand.Longitude)} is required")
            .Must(x => double.TryParse(x, out _))
            .WithMessage($"{nameof(BranchCreateCommand.Longitude)} invalid format");

        RuleFor(x => x.Latitude)
            .NotEmpty()
            .WithMessage($"{nameof(BranchCreateCommand.Latitude)} is required")
            .Must(x => double.TryParse(x, out _))
            .WithMessage($"{nameof(BranchCreateCommand.Latitude)} invalid format");
    }
}
