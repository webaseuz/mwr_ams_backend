using Bms.Core.Application;
using ServiceDesk.Application;

namespace ServiceDesk.Application.UseCases.Accounts;

public class UserInfoDto :
    UserAuthModel
{
    public string PositionName { get; internal set; }
    public string BranchName { get; internal set; }
    public string DepartmentName { get; internal set; }
}
