namespace AutoPark.Application.UseCases.Users;

public class UserBriefDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string FullName { get; set; }
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; }
    public int BranchId { get; set; }
    public string BranchName { get; set; }
    public int? RegionId { get; set; }
    public string RegionName { get; set; }
    public int? DistrictId { get; set; }
    public string DistrictName { get; set; }
    public string CreatedAt { get; set; }
    public string ModifiedAt { get; set; }

    public List<string> Roles { get; set; } = new();
}
