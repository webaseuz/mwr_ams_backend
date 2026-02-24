using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Extensions;
using FluentValidation;

namespace AutoPark.Application.UseCases.Regions;

public class CreateRegionCommandValidator :
    AbstractValidator<CreateRegionCommand>
{
    public CreateRegionCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateRegionCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateRegionCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateRegionCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateRegionCommand.FullName), 1, 250));

        RuleFor(x => x.CountryId)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateRegionCommand.CountryId), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateRegionCommand.CountryId), 1, int.MaxValue));

        RuleFor(x => x.Code)
            .MaximumLength(50)
            .When(x => !x.Code.IsNullOrEmptyObject())
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateRegionCommand.Code), 1, 50));

        RuleFor(x => x.Soato)
                .MaximumLength(50)
                .When(x => !x.Soato.IsNullOrEmptyObject())
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateRegionCommand.Soato), 1, 50));

        RuleFor(x => x.RoamingCode)
            .MaximumLength(50)
            .When(x => !x.RoamingCode.IsNullOrEmptyObject())
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateRegionCommand.RoamingCode), 1, 50));
    }
}
