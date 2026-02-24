namespace AutoPark.Application.UseCases.Banks;

public class DashboardDto
{
    public int? BranchId { get; set; }
    public string BranchName { get; set; }
    public int InSidePersonCount { get; set; }
    public List<long> InSidePersonIds { get; set; } = new();
    public int OutSidePersonCount { get; set; }
    public List<long> OutSidePersonIds { get; set; } = new();
}
