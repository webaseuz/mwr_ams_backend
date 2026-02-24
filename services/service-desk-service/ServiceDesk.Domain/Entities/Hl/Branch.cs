using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("hl_branch")]
public class Branch :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("unique_code")]
    [StringLength(50)]
    public string UniqueCode { get; set; } = null!;

    [Column("parent_id")]
    public int? ParentId { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [Column("organization_id")]
    public int OrganizationId { get; set; }

    [Column("country_id")]
    public int CountryId { get; set; }

    [Column("region_id")]
    public int RegionId { get; set; }

    [Column("district_id")]
    public int DistrictId { get; set; }

    [Column("address")]
    [StringLength(500)]
    public string Address { get; set; } = null!;

    [Column("latitude")]
    [StringLength(50)]
    public string Latitude { get; set; }

    [Column("longitude")]
    [StringLength(50)]
    public string Longitude { get; set; }

    [Column("state_id")]
    public int StateId { get; private set; }

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
    public virtual District District { get; set; } = null!;

    [ForeignKey(nameof(ParentId))]
    public virtual Branch Parent { get; set; }

    [ForeignKey(nameof(RegionId))]
    public virtual Region Region { get; set; } = null!;

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
