using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("hl_person")]
public partial class HlPerson
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("pinfl")]
    [StringLength(14)]
    public string? Pinfl { get; set; }

    [Column("inn")]
    [StringLength(9)]
    public string? Inn { get; set; }

    [Column("document_type_id")]
    public int DocumentTypeId { get; set; }

    [Column("document_seria")]
    [StringLength(50)]
    public string DocumentSeria { get; set; } = null!;

    [Column("document_number")]
    [StringLength(50)]
    public string DocumentNumber { get; set; } = null!;

    [Column("document_start_on", TypeName = "timestamp without time zone")]
    public DateTime? DocumentStartOn { get; set; }

    [Column("document_end_on", TypeName = "timestamp without time zone")]
    public DateTime? DocumentEndOn { get; set; }

    [Column("last_name")]
    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [Column("first_name")]
    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [Column("middle_name")]
    [StringLength(100)]
    public string? MiddleName { get; set; }

    [Column("full_name")]
    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [Column("birth_on", TypeName = "timestamp without time zone")]
    public DateTime BirthOn { get; set; }

    [Column("gender_id")]
    public int? GenderId { get; set; }

    [Column("birth_country_id")]
    public int? BirthCountryId { get; set; }

    [Column("birth_region_id")]
    public int? BirthRegionId { get; set; }

    [Column("birth_district_id")]
    public int? BirthDistrictId { get; set; }

    [Column("citizenship_id")]
    public int? CitizenshipId { get; set; }

    [Column("living_region_id")]
    public int? LivingRegionId { get; set; }

    [Column("living_district_id")]
    public int? LivingDistrictId { get; set; }

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

    [ForeignKey("BirthCountryId")]
    [InverseProperty("HlPeople")]
    public virtual InfoCountry? BirthCountry { get; set; }

    [ForeignKey("BirthDistrictId")]
    [InverseProperty("HlPersonBirthDistricts")]
    public virtual InfoDistrict? BirthDistrict { get; set; }

    [ForeignKey("BirthRegionId")]
    [InverseProperty("HlPersonBirthRegions")]
    public virtual InfoRegion? BirthRegion { get; set; }

    [ForeignKey("CitizenshipId")]
    [InverseProperty("HlPeople")]
    public virtual InfoCitizenship? Citizenship { get; set; }

    [InverseProperty("ResponsiblePerson")]
    public virtual ICollection<DocTransportSettingInspection> DocTransportSettingInspections { get; set; } = new List<DocTransportSettingInspection>();

    [InverseProperty("ResponsiblePerson")]
    public virtual ICollection<DocTransportSettingInsurance> DocTransportSettingInsurances { get; set; } = new List<DocTransportSettingInsurance>();

    [InverseProperty("ResponsiblePerson")]
    public virtual ICollection<DocTransportSetting> DocTransportSettings { get; set; } = new List<DocTransportSetting>();

    [ForeignKey("DocumentTypeId")]
    [InverseProperty("HlPeople")]
    public virtual EnumDocumentType DocumentType { get; set; } = null!;

    [ForeignKey("GenderId")]
    [InverseProperty("HlPeople")]
    public virtual EnumGender? Gender { get; set; }

    [InverseProperty("Person")]
    public virtual ICollection<HlDriver> HlDrivers { get; set; } = new List<HlDriver>();

    [ForeignKey("LivingDistrictId")]
    [InverseProperty("HlPersonLivingDistricts")]
    public virtual InfoDistrict? LivingDistrict { get; set; }

    [ForeignKey("LivingRegionId")]
    [InverseProperty("HlPersonLivingRegions")]
    public virtual InfoRegion? LivingRegion { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("HlPeople")]
    public virtual EnumState State { get; set; } = null!;

    [InverseProperty("Person")]
    public virtual ICollection<SysUser> SysUsers { get; set; } = new List<SysUser>();
}
