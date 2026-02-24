using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_district")]
public partial class InfoDistrict
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string? OrderCode { get; set; }

    [Column("code")]
    [StringLength(50)]
    public string? Code { get; set; }

    [Column("soato")]
    [StringLength(50)]
    public string? Soato { get; set; }

    [Column("roaming_code")]
    [StringLength(50)]
    public string? RoamingCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [Column("region_id")]
    public int RegionId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    [InverseProperty("District")]
    public virtual ICollection<HlBranch> HlBranches { get; set; } = new List<HlBranch>();

    [InverseProperty("BirthDistrict")]
    public virtual ICollection<HlPerson> HlPersonBirthDistricts { get; set; } = new List<HlPerson>();

    [InverseProperty("LivingDistrict")]
    public virtual ICollection<HlPerson> HlPersonLivingDistricts { get; set; } = new List<HlPerson>();

    [InverseProperty("District")]
    public virtual ICollection<InfoContractor> InfoContractors { get; set; } = new List<InfoContractor>();

    [InverseProperty("Owner")]
    public virtual ICollection<InfoDistrictTranslate> InfoDistrictTranslates { get; set; } = new List<InfoDistrictTranslate>();

    [InverseProperty("District")]
    public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; } = new List<InfoOrganization>();

    [ForeignKey("RegionId")]
    [InverseProperty("InfoDistricts")]
    public virtual InfoRegion Region { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("InfoDistricts")]
    public virtual EnumState State { get; set; } = null!;
}
