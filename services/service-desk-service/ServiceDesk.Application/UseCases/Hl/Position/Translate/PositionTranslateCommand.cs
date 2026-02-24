using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Positions;

public class PositionTranslateCommand :
	TranslateCommand<PositionTranslateCommand, PositionTranslate, TranslateColumn>
{
}
