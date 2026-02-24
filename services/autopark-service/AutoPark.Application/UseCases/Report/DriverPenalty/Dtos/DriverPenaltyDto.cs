namespace AutoPark.Application.UseCases.DriverPenalties;

public class DriverPenaltyDto
{
    public long Id { get; set; }
    public int BranchId { get; set; }
    public string BranchName { get; set; }
    public int DriverId { get; set; }
    public string FullName { get; set; }
    public int TransportId { get; set; }
    public string TransportModelName { get; set; }
    public string RegistrationNumber { get; set; }
    public decimal Amount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal Discount50Amount { get; set; }
    public DateTime? Discount50Date { get; set; }
    public decimal DiscountAmount { get; set; }
    public DateTime? DiscountDate { get; set; }
    public string MibCaseNumber { get; set; }
    public string MibCaseStatus { get; set; }
    public DateTime? MibSendTime { get; set; }
    public bool IsCritical { get; set; }

    public DateTime? LastPayTime { get; set; }
    public string CaseOrgan { get; set; }
    public string DecisionOrgan { get; set; }
    public string DecisionArticlePart { get; set; }
    public string DecisionCity { get; set; }
    public string DecisionPassport { get; set; }
    public string DecisionStatus { get; set; }
    public DateTime? DecisionTime { get; set; }
    public string DecisionViolationType { get; set; }
    public string DecisionPdf { get; set; }
    public bool? InvoiceIsActive { get; set; }
    public string InvoiceSerial { get; set; }
}
