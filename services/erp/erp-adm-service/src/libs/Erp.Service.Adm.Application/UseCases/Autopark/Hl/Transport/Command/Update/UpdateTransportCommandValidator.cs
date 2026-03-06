using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UpdateTransportCommandValidator : AbstractValidator<TransportUpdateCommand>
{
    public UpdateTransportCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0).WithMessage($"{nameof(TransportUpdateCommand.Id)} is required");
        RuleFor(x => x.BranchId).NotNull().GreaterThan(0).WithMessage($"{nameof(TransportUpdateCommand.BranchId)} is required");
        RuleFor(x => x.TransportModelId).NotNull().GreaterThan(0).WithMessage($"{nameof(TransportUpdateCommand.TransportModelId)} is required");
        RuleFor(x => x.TransportUseTypeId).NotNull().GreaterThan(0).WithMessage($"{nameof(TransportUpdateCommand.TransportUseTypeId)} is required");
        RuleFor(x => x.TransportBrandId).NotNull().GreaterThan(0).WithMessage($"{nameof(TransportUpdateCommand.TransportBrandId)} is required");
        RuleFor(x => x.TransportColorId).NotNull().GreaterThan(0).WithMessage($"{nameof(TransportUpdateCommand.TransportColorId)} is required");
        RuleFor(x => x.StateCode).NotEmpty().WithMessage($"{nameof(TransportUpdateCommand.StateCode)} is required");
        RuleFor(x => x.StateNumber).NotEmpty().WithMessage($"{nameof(TransportUpdateCommand.StateNumber)} is required");
        RuleFor(x => x.VinNumber).NotEmpty().WithMessage($"{nameof(TransportUpdateCommand.VinNumber)} is required");
    }
}
