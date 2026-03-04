using Erp.Core;
using Erp.Core.Models;

namespace Erp.Service.Adm.Job.Models;
public class RoleDto : ISysEntity<int>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public bool IsAdm.Jobin { get; set; }
    public int AppId { get; set; }
    public string AppName { get; set; }
    public List<int> Permissions { get; set; } = new List<int>();
    public List<RolePositionDto> Positions { get; set; } = new();
    public int TableId { get; } = TableIdConst.ADM.JOB_SYS_ROLE;
}
