using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases.Document.Refuel;

public class UploadRefuelFileCommandValidator : AbstractValidator<RefuelFileUploadCommand>
{
    public UploadRefuelFileCommandValidator()
    {
        RuleFor(x => x.Files).NotEmpty().WithMessage($"{nameof(RefuelFileUploadCommand.Files)} is required");
    }
}
