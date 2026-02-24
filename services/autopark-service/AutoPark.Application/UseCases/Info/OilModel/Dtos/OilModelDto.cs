namespace AutoPark.Application.UseCases.OilModels;

public class OilModelDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int OilTypeId { get; set; }
    public string OilTypeName { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; }
    public List<OilModelTranslateDto> Translates { get; set; } = new();
}
