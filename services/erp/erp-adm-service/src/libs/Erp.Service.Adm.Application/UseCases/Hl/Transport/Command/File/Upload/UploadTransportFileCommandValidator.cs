using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UploadTransportFileCommandValidator : AbstractValidator<TransportFileUploadCommand>
{
    public UploadTransportFileCommandValidator()
    {
        RuleFor(x => x.Files).NotEmpty().WithMessage($"{nameof(TransportFileUploadCommand.Files)} is required");
    }
}
