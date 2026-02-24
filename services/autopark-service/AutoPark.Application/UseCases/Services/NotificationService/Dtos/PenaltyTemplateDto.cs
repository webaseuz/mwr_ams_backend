namespace AutoPark.Application.UseCases.NotificationServices;

public class PenaltyTemplateDto
{
    public string DriverName { get; set; }
    public decimal FineAmount { get; set; }
    public string FineDate { get; set; }
    public string CarNumber { get; set; }
    public string DiscountDeadline { get; set; }
    public string FullPaymentDeadline { get; set; }
}
