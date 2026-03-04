using Erp.Core;
using Erp.Core.Models;

namespace Erp.Service.Adm.Models;
public class RoleDto : ISysEntity<int>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public bool IsAdmin { get; set; }
    public int AppId { get; set; }
    public string AppName { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public List<int> Permissions { get; set; } = new List<int>();
    public List<RolePositionDto> Positions { get; set; } = new();
    public int TableId { get; } = TableIdConst.ADM_SYS_ROLE;
}
