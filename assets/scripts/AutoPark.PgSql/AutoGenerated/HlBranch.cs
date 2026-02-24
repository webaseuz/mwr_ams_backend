using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("hl_branch")]
public partial class HlBranch
{
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
    public string? Latitude { get; set; }

    [Column("longitude")]
    [StringLength(50)]
    public string? Longitude { get; set; }

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

    [ForeignKey("CountryId")]
    [InverseProperty("HlBranches")]
    public virtual InfoCountry Country { get; set; } = null!;

    [ForeignKey("DistrictId")]
    [InverseProperty("HlBranches")]
    public virtual InfoDistrict District { get; set; } = null!;

    [InverseProperty("Branch")]
    public virtual ICollection<HlDepartment> HlDepartments { get; set; } = new List<HlDepartment>();

    [InverseProperty("Branch")]
    public virtual ICollection<HlDriver> HlDrivers { get; set; } = new List<HlDriver>();

    [InverseProperty("Branch")]
    public virtual ICollection<HlTransport> HlTransports { get; set; } = new List<HlTransport>();

    [InverseProperty("Parent")]
    public virtual ICollection<HlBranch> InverseParent { get; set; } = new List<HlBranch>();

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual HlBranch? Parent { get; set; }

    [ForeignKey("RegionId")]
    [InverseProperty("HlBranches")]
    public virtual InfoRegion Region { get; set; } = null!;

    [InverseProperty("Branch")]
    public virtual ICollection<SysNumber> SysNumbers { get; set; } = new List<SysNumber>();

    [InverseProperty("Branch")]
    public virtual ICollection<SysUser> SysUsers { get; set; } = new List<SysUser>();
}
