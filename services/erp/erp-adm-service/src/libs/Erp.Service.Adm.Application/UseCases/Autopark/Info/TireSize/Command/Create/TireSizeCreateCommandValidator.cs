using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TireSizeCreateCommandValidator : AbstractValidator<TireSizeCreateCommand>
{
    public TireSizeCreateCommandValidator()
    {
        // No validation rules
    }
}
