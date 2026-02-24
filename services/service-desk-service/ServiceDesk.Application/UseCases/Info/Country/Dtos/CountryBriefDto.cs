namespace ServiceDesk.Application.UseCases.Countries;

public class CountryBriefDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; } = null!;
    public string TextCode { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int StateId { get; set; }
    public string StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
