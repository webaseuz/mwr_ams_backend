using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.OilModels;

public class OilModelTranslateCommand :
    TranslateCommand<OilModelTranslateCommand, OilModelTranslate, TranslateColumn>
{
}
