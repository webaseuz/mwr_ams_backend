using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Districts;

public class DistrictTranslateCommand :
    TranslateCommand<DistrictTranslateCommand, DistrictTranslate, TranslateColumn>
{ }
