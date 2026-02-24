using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.OilTypes;

public class OilTypeTranslateCommand :
    TranslateCommand<OilTypeTranslateCommand, OilTypeTranslate, TranslateColumn>
{
}
