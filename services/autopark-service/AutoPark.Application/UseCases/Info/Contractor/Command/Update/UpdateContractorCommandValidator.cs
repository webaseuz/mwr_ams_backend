using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Extensions;
using FluentValidation;

namespace AutoPark.Application.UseCases.Info.Contractors;

public class UpdateContractorCommandValidator :
    AbstractValidator<UpdateContractorCommand>
{
    public UpdateContractorCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.Id), 1, int.MaxValue));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateContractorCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateContractorCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.FullName), 1, 250));

        RuleFor(x => x.Address)
            .MinimumLength(5)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.Address), 5, 250));

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(15)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.PhoneNumber), 1, 15));

        RuleFor(x => x.CountryId)
           .GreaterThan(0)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.CountryId), 1, int.MaxValue))
           .LessThan(int.MaxValue)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.CountryId), 1, int.MaxValue));

        RuleFor(x => x.RegionId)
           .GreaterThan(0)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.RegionId), 1, int.MaxValue))
           .LessThan(int.MaxValue)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.RegionId), 1, int.MaxValue));

        RuleFor(x => x.DistrictId)
           .GreaterThan(0)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.DistrictId), 1, int.MaxValue))
           .LessThan(int.MaxValue)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.DistrictId), 1, int.MaxValue));

        RuleFor(x => x.BankId)
         .GreaterThan(0)
         .When(x => !x.BankId.IsNullOrEmptyObject())
         .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.BankId), 1, int.MaxValue))
         .LessThan(int.MaxValue)
         .When(x => !x.BankId.IsNullOrEmptyObject())
         .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.BankId), 1, int.MaxValue));

        RuleFor(x => x.ContactInfo)
           .MaximumLength(250)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.ContactInfo), 1, 250));

        RuleFor(x => x.Inn)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateContractorCommand.Inn)))
            .MaximumLength(9)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.Inn), 9, 9))
            .MinimumLength(9)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.Inn), 9, 9));

        RuleFor(x => x.Accounter)
           .MaximumLength(250)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.Accounter), 1, 250));

        RuleFor(x => x.Director)
          .MaximumLength(250)
          .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.Director), 1, 250));

        RuleFor(x => x.VatCode)
          .MaximumLength(30)
          .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateContractorCommand.Accounter), 1, 30));

    }
}
