using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CreateTransportCommandValidator : AbstractValidator<TransportCreateCommand>
{
    public CreateTransportCommandValidator()
    {
        RuleFor(x => x.BranchId).NotNull().GreaterThan(0).WithMessage($"{nameof(TransportCreateCommand.BranchId)} is required");
        RuleFor(x => x.TransportModelId).NotNull().GreaterThan(0).WithMessage($"{nameof(TransportCreateCommand.TransportModelId)} is required");
        RuleFor(x => x.TransportUseTypeId).NotNull().GreaterThan(0).WithMessage($"{nameof(TransportCreateCommand.TransportUseTypeId)} is required");
        RuleFor(x => x.TransportBrandId).NotNull().GreaterThan(0).WithMessage($"{nameof(TransportCreateCommand.TransportBrandId)} is required");
        RuleFor(x => x.TransportColorId).NotNull().GreaterThan(0).WithMessage($"{nameof(TransportCreateCommand.TransportColorId)} is required");
        RuleFor(x => x.StateCode).NotEmpty().WithMessage($"{nameof(TransportCreateCommand.StateCode)} is required");
        RuleFor(x => x.StateNumber).NotEmpty().WithMessage($"{nameof(TransportCreateCommand.StateNumber)} is required");
        RuleFor(x => x.VinNumber).NotEmpty().WithMessage($"{nameof(TransportCreateCommand.VinNumber)} is required");
    }
}
