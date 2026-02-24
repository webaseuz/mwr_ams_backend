using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Regions;

public class RegionTranslateCommand:
	TranslateCommand<RegionTranslateCommand, RegionTranslate, TranslateColumn>
{
}
