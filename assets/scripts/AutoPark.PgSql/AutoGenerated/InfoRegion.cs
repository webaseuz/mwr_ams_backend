using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_region")]
public partial class InfoRegion
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

    [Column("state_code")]
    [StringLength(5)]
    public string StateCode { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [Column("country_id")]
    public int CountryId { get; set; }

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

    [ForeignKey("CountryId")]
    [InverseProperty("InfoRegions")]
    public virtual InfoCountry Country { get; set; } = null!;

    [InverseProperty("Region")]
    public virtual ICollection<HlBranch> HlBranches { get; set; } = new List<HlBranch>();

    [InverseProperty("BirthRegion")]
    public virtual ICollection<HlPerson> HlPersonBirthRegions { get; set; } = new List<HlPerson>();

    [InverseProperty("LivingRegion")]
    public virtual ICollection<HlPerson> HlPersonLivingRegions { get; set; } = new List<HlPerson>();

    [InverseProperty("Region")]
    public virtual ICollection<InfoContractor> InfoContractors { get; set; } = new List<InfoContractor>();

    [InverseProperty("Region")]
    public virtual ICollection<InfoDistrict> InfoDistricts { get; set; } = new List<InfoDistrict>();

    [InverseProperty("Region")]
    public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; } = new List<InfoOrganization>();

    [InverseProperty("Owner")]
    public virtual ICollection<InfoRegionTranslate> InfoRegionTranslates { get; set; } = new List<InfoRegionTranslate>();

    [ForeignKey("StateId")]
    [InverseProperty("InfoRegions")]
    public virtual EnumState State { get; set; } = null!;
}
