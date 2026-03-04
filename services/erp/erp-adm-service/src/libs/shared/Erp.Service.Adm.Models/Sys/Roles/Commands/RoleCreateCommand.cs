using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class RoleCreateCommand : IRequest<WbHaveId<int>>
{
    public int AppId { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public bool IsAdmin { get; set; }
    public List<int> Permissions { get; set; } = new List<int>();
    public List<RolePositionCreateUpdateCommand> Positions { get; set; } = new();

    public List<RolesTranslateCreateUpdateCommand> Translates { get; set; } = new List<RolesTranslateCreateUpdateCommand>();

}
