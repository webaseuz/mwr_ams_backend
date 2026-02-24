using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Extensions;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Info.Contractors;

public class CreateContractorCommandValidator :
       AbstractValidator<CreateContractorCommand>
{
    public CreateContractorCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateContractorCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateContractorCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.FullName), 1, 250));

        RuleFor(x => x.Address)
            .MinimumLength(5)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.Address), 5, 250));

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(15)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.PhoneNumber), 1, 15));

        RuleFor(x => x.CountryId)
           .GreaterThan(0)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.CountryId), 1, int.MaxValue))
           .LessThan(int.MaxValue)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.CountryId), 1, int.MaxValue));

        RuleFor(x => x.RegionId)
           .GreaterThan(0)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.RegionId), 1, int.MaxValue))
           .LessThan(int.MaxValue)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.RegionId), 1, int.MaxValue));

        RuleFor(x => x.DistrictId)
           .GreaterThan(0)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.DistrictId), 1, int.MaxValue))
           .LessThan(int.MaxValue)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.DistrictId), 1, int.MaxValue));

        RuleFor(x => x.BankId)
         .GreaterThan(0)
         .When(x => !x.BankId.IsNullOrEmptyObject())
         .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.BankId), 1, int.MaxValue))
         .LessThan(int.MaxValue)
         .When(x => !x.BankId.IsNullOrEmptyObject())
         .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.BankId), 1, int.MaxValue));

        RuleFor(x => x.ContactInfo)
           .MaximumLength(250)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.ContactInfo), 1, 250));

        RuleFor(x => x.Inn)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateContractorCommand.Inn)))
            .MaximumLength(9)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.Inn), 9, 9))
            .MinimumLength(9)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.Inn), 9, 9));

        RuleFor(x => x.Accounter)
           .MaximumLength(250)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.Accounter), 1, 250));

        RuleFor(x => x.Director)
          .MaximumLength(250)
          .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.Director), 1, 250));

        RuleFor(x => x.VatCode)
          .MaximumLength(30)
          .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateContractorCommand.Accounter), 1, 30));
    }
}