namespace AutoPark.Application.UseCases.TireModels;

public class TireModelBriefDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int StateId { get; set; }
    public string StateName { get; set; }

    public bool CanModify { get; set; }
    public bool CanDelete { get; set; }
    public bool CanView { get; set; }
}
