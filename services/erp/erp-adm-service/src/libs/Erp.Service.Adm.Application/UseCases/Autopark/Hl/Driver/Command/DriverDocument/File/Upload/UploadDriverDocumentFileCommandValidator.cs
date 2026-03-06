using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UploadDriverDocumentFileCommandValidator : AbstractValidator<DriverDocumentUploadCommand>
{
    public UploadDriverDocumentFileCommandValidator()
    {
        RuleFor(x => x.Files)
            .NotEmpty()
            .WithMessage($"{nameof(DriverDocumentUploadCommand.Files)} is required");
    }
}
