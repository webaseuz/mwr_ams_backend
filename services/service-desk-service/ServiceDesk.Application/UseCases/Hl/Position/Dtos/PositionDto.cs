namespace ServiceDesk.Application.UseCases.Positions;

public class PositionDto
{
	public int Id { get; set; }
	public string ShortName { get; set; } = null!;
	public string FullName { get; set; } = null!;
	public string Code { get; set; }
	public string OrderCode { get; set; }
	public int StateId { get; set; }
	public string StateName { get; set; } = null!;
	public List<PositionTranslateDto> Translates { get; set; } = new();
}
