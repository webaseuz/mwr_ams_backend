using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Organizations;

public class OrganizationTranslateCommand :
    TranslateCommand<OrganizationTranslateCommand, OrganizationTranslate, TranslateColumn>
{
}
