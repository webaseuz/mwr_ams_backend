using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("acc_driver_penalty")]
public class DriverPenalty :
    IHaveIdProp<long>
{
    #region Properties  
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Required]
    [Column("branch_id")]
    public int BranchId { get; set; }

    [Required]
    [Column("person_id")]
    public long PersonId { get; set; }

    [Required]
    [Column("transport_id")]
    public int TransportId { get; set; }

    [Required]
    [Column("registration_number")]
    [StringLength(50)]
    public string RegistrationNumber { get; set; }

    [Required]
    [Column("external_id")]
    public long ExternalId { get; set; }


    [Required]
    [Column("second_name_lat")]
    [StringLength(100)]
    public string SecondNameLat { get; set; }

    [Required]
    [Column("last_name_lat")]
    [StringLength(100)]
    public string LastNameLat { get; set; }

    [Required]
    [Column("first_name_lat")]
    [StringLength(100)]
    public string FirstNameLat { get; set; }


    [Column("amount", TypeName = "numeric(18,2)")]
    public decimal Amount { get; set; }

    [Column("paid_amount", TypeName = "numeric(18,2)")]
    public decimal PaidAmount { get; set; }

    [Column("last_pay_time", TypeName = "timestamp without time zone")]
    public DateTime? LastPayTime { get; set; }

    [Column("case_organ")]
    [StringLength(300)]
    public string CaseOrgan { get; set; }


    [Column("decision_organ")]
    [StringLength(300)]
    public string DecisionOrgan { get; set; }

    [Column("decision_article_part")]
    [StringLength(50)]
    public string DecisionArticlePart { get; set; }

    [Column("decision_city")]
    [StringLength(200)]
    public string DecisionCity { get; set; }

    [Column("decision_passport")]
    [StringLength(50)]
    public string DecisionPassport { get; set; }

    [Column("decision_status")]
    [StringLength(50)]
    public string DecisionStatus { get; set; }

    [Column("decision_time", TypeName = "timestamp without time zone")]
    public DateTime? DecisionTime { get; set; }

    [Column("decision_violation_type")]
    [StringLength(50)]
    public string DecisionViolationType { get; set; }

    [Column("decision_pdf")]
    [StringLength(500)]
    public string DecisionPdf { get; set; }


    [Column("discount50_amount", TypeName = "numeric(18,2)")]
    public decimal Discount50Amount { get; set; }

    [Column("discount50_date")]
    public DateTime? Discount50Date { get; set; }

    [Column("discount_amount", TypeName = "numeric(18,2)")]
    public decimal DiscountAmount { get; set; }

    [Column("discount_date")]
    public DateTime? DiscountDate { get; set; }


    [Column("invoice_is_active")]
    public bool? InvoiceIsActive { get; set; }

    [Column("invoice_serial")]
    [StringLength(50)]
    public string InvoiceSerial { get; set; }


    [Column("mib_case_number")]
    [StringLength(100)]
    public string MibCaseNumber { get; set; }

    [Column("mib_case_status")]
    [StringLength(50)]
    public string MibCaseStatus { get; set; }

    [Column("mib_send_time", TypeName = "timestamp without time zone")]
    public DateTime? MibSendTime { get; set; }


    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    #endregion

    #region Relationships

    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; }

    [ForeignKey(nameof(PersonId))]
    public virtual Person Person { get; set; }

    [ForeignKey(nameof(TransportId))]
    public virtual Transport Transport { get; set; }

    #endregion
}