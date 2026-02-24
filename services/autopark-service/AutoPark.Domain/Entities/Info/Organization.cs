using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_organization")]
public class Organization :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public Organization()
    {
        Translates = new HashSet<OrganizationTranslate>();
    }

    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(300)]
    public string FullName { get; set; } = null!;

    [Column("inn")]
    [StringLength(9)]
    public string Inn { get; set; }

    [Column("parent_id")]
    public int? ParentId { get; set; }

    [Column("country_id")]
    public int CountryId { get; set; }

    [Column("region_id")]
    public int RegionId { get; set; }

    [Column("district_id")]
    public int? DistrictId { get; set; }

    [Column("address")]
    [StringLength(500)]
    public string Address { get; set; }

    [Column("phone_number")]
    [StringLength(250)]
    public string PhoneNumber { get; set; }

    [Column("oked_id")]
    [NotMapped]
    public int? OkedId { get; set; }

    [Column("director")]
    [StringLength(250)]
    public string Director { get; set; }

    [Column("vat_code")]
    [StringLength(12)]
    public string VatCode { get; set; }

    [Column("zip_code")]
    [StringLength(50)]
    public string ZipCode { get; set; }

    [Column("latitude")]
    [StringLength(50)]
    public string Latitude { get; set; }

    [Column("longitude")]
    [StringLength(50)]
    public string Longitude { get; set; }

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
    [ForeignKey(nameof(CountryId))]
    public virtual Country Country { get; set; } = null!;

    [ForeignKey(nameof(DistrictId))]
    public virtual District District { get; set; }

    [ForeignKey(nameof(RegionId))]
    public virtual Region Region { get; set; } = null!;

    [InverseProperty(nameof(OrganizationTranslate.Owner))]
    public virtual ICollection<OrganizationTranslate> Translates { get; set; } = new List<OrganizationTranslate>();


    [ForeignKey(nameof(ParentId))]
    public virtual Organization Parent { get; set; }

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;

    #endregion

    #region Methods
    public void MarkAsActive()
        => StateId = StateIdConst.ACTIVE;

    public void MarkAsPassive()
        => StateId = StateIdConst.PASSIVE;
    #endregion

}
