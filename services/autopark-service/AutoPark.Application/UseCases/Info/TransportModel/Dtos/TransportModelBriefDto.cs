namespace AutoPark.Application.UseCases.TransportModels;

public class TransportModelBriefDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int TransportTypeId { get; set; }
    public string TransportTypeName { get; set; }
    public int TransportBrandId { get; set; }
    public string TransportBrandName { get; set; }
    public int TransportModelLiquidId { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public bool CanModify { get; set; }
    public bool CanDelete { get; set; }
    public bool CanView { get; set; }

    public List<TransportModelTranslateDto> Translates { get; set; } = new();
}
