using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Extensions;
using FluentValidation;

namespace AutoPark.Application.UseCases.Organizations;

public class UpdateOrganizationCommandValidator :
    AbstractValidator<UpdateOrganizationCommand>
{
    public UpdateOrganizationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateOrganizationCommand.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateOrganizationCommand.Id), 1, int.MaxValue));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateOrganizationCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateOrganizationCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateOrganizationCommand.FullName)))
            .MaximumLength(300)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateOrganizationCommand.FullName), 1, 300));

        RuleFor(x => x.Inn)
            .Matches(@"^\d{9}$|^\d{14}$")
            .When(x => !string.IsNullOrEmpty(x.Inn))
            .WithMessage(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(UpdateOrganizationCommand.Inn)).Message);

        RuleFor(x => x.CountryId)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateOrganizationCommand.CountryId), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateOrganizationCommand.CountryId), 1, int.MaxValue));

        RuleFor(x => x.RegionId)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateOrganizationCommand.RegionId), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateOrganizationCommand.RegionId), 1, int.MaxValue));

        RuleFor(x => x.DistrictId)
            .GreaterThan(0)
            .When(x => x.DistrictId != null)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateOrganizationCommand.CountryId), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .When(x => x.DistrictId != null)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateOrganizationCommand.CountryId), 1, int.MaxValue));

        RuleFor(x => x.Address)
            .MaximumLength(500)
            .When(x => !x.Address.IsNullOrEmptyObject())
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateOrganizationCommand.Address), 1, 500));

        RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .When(x => !x.PhoneNumber.IsNullOrEmptyObject())
                .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(UpdateOrganizationCommand.PhoneNumber)));

        RuleFor(x => x.Director)
            .MaximumLength(250)
            .When(x => !x.Director.IsNullOrEmptyObject())
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateOrganizationCommand.Director), 1, 250));


        RuleFor(x => x.Latitude)
            .MaximumLength(50)
            .When(x => !x.Latitude.IsNullOrEmptyObject())
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateOrganizationCommand.Latitude), 1, 50));


        RuleFor(x => x.Longitude)
            .MaximumLength(50)
            .When(x => !x.Longitude.IsNullOrEmptyObject())
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateOrganizationCommand.Longitude), 1, 50));
    }
}
