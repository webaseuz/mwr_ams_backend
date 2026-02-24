namespace AutoPark.Application.UseCases.TransportBrands;

public class TransportBrandDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int StateId { get; set; }
    public string StateName { get; set; } = null!;
    public List<TransportBrandTranslateDto> Translates { get; set; } = new();
}
