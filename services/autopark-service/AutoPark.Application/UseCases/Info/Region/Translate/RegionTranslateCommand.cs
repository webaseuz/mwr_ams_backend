using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Regions;

public class RegionTranslateCommand :
    TranslateCommand<RegionTranslateCommand, RegionTranslate, TranslateColumn>
{
}
