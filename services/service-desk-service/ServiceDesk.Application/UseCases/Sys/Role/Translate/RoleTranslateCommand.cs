using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Roles;

public class RoleTranslateCommand :
	TranslateCommand<RoleTranslateCommand, RoleTranslate, TranslateColumn>
{
}
