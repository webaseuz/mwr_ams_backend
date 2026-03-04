using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UploadTransportSettingFileCommandValidator : AbstractValidator<TransportSettingFileUploadCommand>
{
    public UploadTransportSettingFileCommandValidator()
    {
        RuleFor(x => x.Files).NotEmpty().WithMessage($"{nameof(TransportSettingFileUploadCommand.Files)} is required");
    }
}
