namespace Erp.Service.Adm.Application.UseCases;

public class UserAccess
{
    public bool CanViewAllOrganizations { get; set; }
}

public class UserInfoDto : UserAuthModel
{
    public string PositionName { get; set; }
    public string BranchName { get; set; }
    public string DepartmentName { get; set; }
    public UserAccess UserAccess { get; set; }
}
