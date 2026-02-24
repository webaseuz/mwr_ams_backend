using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Roles;

public class RoleTranslateCommand :
    TranslateCommand<RoleTranslateCommand, RoleTranslate, TranslateColumn>
{
}
