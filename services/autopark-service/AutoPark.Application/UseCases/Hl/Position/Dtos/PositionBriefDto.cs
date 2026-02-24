namespace AutoPark.Application.UseCases.Positions;

public class PositionBriefDto
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string Code { get; set; }
    public string OrderCode { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
