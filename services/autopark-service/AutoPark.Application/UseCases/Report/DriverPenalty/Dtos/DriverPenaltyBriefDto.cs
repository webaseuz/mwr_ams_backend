namespace AutoPark.Application.UseCases.DriverPenalties;

public class DriverPenaltyBriefDto
{
    public long Id { get; set; }
    public int RegionId { get; set; }
    public int BranchId { get; set; }
    public long PersonId { get; set; }
    public string BranchName { get; set; }
    public string DecisionStatus { get; set; }
    public int DriverId { get; set; }
    public string FullName { get; set; }
    public int TransportId { get; set; }
    public string TransportModelName { get; set; }
    public string RegistrationNumber { get; set; }
    public decimal Amount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal Discount50Amount { get; set; }
    public DateTime? Discount50Date { get; set; }
    public DateTime? DiscountDate { get; set; }
    public string MibCaseNumber { get; set; }
    public string MibCaseStatus { get; set; }
    public DateTime? MibSendTime { get; set; }
    public bool IsCritical { get; set; }
    public bool CanPay { get; set; }
    public DateTime CreatedAt { get; set; }
}
