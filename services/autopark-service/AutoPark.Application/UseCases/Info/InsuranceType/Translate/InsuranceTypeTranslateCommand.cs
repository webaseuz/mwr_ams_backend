using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class InsuranceTypeTranslateCommand :
    TranslateCommand<InsuranceTypeTranslateCommand, InsuranceTypeTranslate, TranslateColumn>
{ }
