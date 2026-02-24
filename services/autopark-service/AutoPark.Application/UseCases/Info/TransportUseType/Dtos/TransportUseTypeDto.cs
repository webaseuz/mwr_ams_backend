namespace AutoPark.Application.UseCases.TransportUseTypes;

public class TransportUseTypeDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int StateId { get; set; }
    public string StateName { get; set; } = null!;
    public List<TransportUseTypeTranslateDto> Translates { get; set; } = new();
}
