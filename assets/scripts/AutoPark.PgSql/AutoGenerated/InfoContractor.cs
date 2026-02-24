using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_contractor")]
public partial class InfoContractor
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [Column("country_id")]
    public int CountryId { get; set; }

    [Column("region_id")]
    public int RegionId { get; set; }

    [Column("district_id")]
    public int DistrictId { get; set; }

    [Column("bank_id")]
    public int BankId { get; set; }

    [Column("address")]
    [StringLength(500)]
    public string? Address { get; set; }

    [Column("phone_number")]
    [StringLength(15)]
    public string? PhoneNumber { get; set; }

    [Column("contact_info")]
    [StringLength(250)]
    public string? ContactInfo { get; set; }

    [Column("inn")]
    [StringLength(9)]
    public string Inn { get; set; } = null!;

    [Column("accounter")]
    [StringLength(250)]
    public string? Accounter { get; set; }

    [Column("director")]
    [StringLength(250)]
    public string? Director { get; set; }

    [Column("vat_code")]
    [StringLength(30)]
    public string? VatCode { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

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

    [ForeignKey("BankId")]
    [InverseProperty("InfoContractors")]
    public virtual InfoBank Bank { get; set; } = null!;

    [ForeignKey("CountryId")]
    [InverseProperty("InfoContractors")]
    public virtual InfoCountry Country { get; set; } = null!;

    [ForeignKey("DistrictId")]
    [InverseProperty("InfoContractors")]
    public virtual InfoDistrict District { get; set; } = null!;

    [InverseProperty("Contractor")]
    public virtual ICollection<DocExpense> DocExpenses { get; set; } = new List<DocExpense>();

    [InverseProperty("Contractor")]
    public virtual ICollection<DocTransportSettingInsurance> DocTransportSettingInsurances { get; set; } = new List<DocTransportSettingInsurance>();

    [ForeignKey("RegionId")]
    [InverseProperty("InfoContractors")]
    public virtual InfoRegion Region { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("InfoContractors")]
    public virtual EnumState State { get; set; } = null!;
}
