namespace AutoPark.Application.UseCases.Currencies;

public class CurrencyBriefDto
{
    public int Id { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string TextCode { get; set; } = null!;
    public int StateId { get; set; }
    public string StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
