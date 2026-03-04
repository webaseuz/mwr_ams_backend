using MediatR;

namespace Erp.Service.Adm.Models;
public class RoleUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int AppId { get; set; }
    public bool IsAdmin { get; set; }
    public int StateId { get; set; }
    public List<int> Permissions { get; set; } = new List<int>();
    public List<RolePositionCreateUpdateCommand> Positions { get; set; } = new();
    public List<RolesTranslateCreateUpdateCommand> Translates { get; set; } = new List<RolesTranslateCreateUpdateCommand>();

}
