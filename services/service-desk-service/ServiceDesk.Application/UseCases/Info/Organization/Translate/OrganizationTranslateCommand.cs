using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Organizations;

public class OrganizationTranslateCommand :
	TranslateCommand<OrganizationTranslateCommand, OrganizationTranslate, TranslateColumn>
{
}
