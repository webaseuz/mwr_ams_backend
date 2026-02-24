namespace AutoPark.Application.UseCases.OilTypes;

public class OilTypeDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int StateId { get; set; }
    public string StateName { get; set; }
    public List<OilTypeTranslateDto> Translates { get; set; } = new();
}
