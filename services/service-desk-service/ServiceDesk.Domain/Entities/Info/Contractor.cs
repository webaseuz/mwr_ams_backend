using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("info_contractor")]
public class Contractor :
    IHaveIdProp<long>,
    IHaveSoftStateId
{
    #region Properties
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
    public int? BankId { get; set; }

    [Column("address")]
    [StringLength(500)]
    public string Address { get; set; }

    [Column("phone_number")]
    [StringLength(15)]
    public string PhoneNumber { get; set; }

    [Column("contact_info")]
    [StringLength(250)]
    public string ContactInfo { get; set; }

    [Column("inn")]
    [StringLength(9)]
    public string Inn { get; set; } = null!;

    [Column("accounter")]
    [StringLength(250)]
    public string Accounter { get; set; }

    [Column("director")]
    [StringLength(250)]
    public string Director { get; set; }

    [Column("vat_code")]
    [StringLength(30)]
    public string VatCode { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }

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
    [ForeignKey(nameof(BankId))]
    public virtual Bank Bank { get; set; } = null!;

    [ForeignKey(nameof(CountryId))]
    public virtual Country Country { get; set; } = null!;

    [ForeignKey(nameof(DistrictId))]
    public virtual District District { get; set; } = null!;

    [ForeignKey(nameof(RegionId))]
    public virtual Region Region { get; set; } = null!;

    [ForeignKey(nameof(StateId))]   
    public virtual State State { get; set; }

    #endregion

    #region Methods
    public void MarkAsPassive()
        => StateId = StateIdConst.PASSIVE;

    public void MarkAsActive()
        => StateId = StateIdConst.ACTIVE;
    

    #endregion
}
