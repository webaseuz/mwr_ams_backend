using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("info_country")]
[Index("Code", Name = "uix_info_country__code", IsUnique = true)]
[Index("TextCode", Name = "uix_info_country__text_code", IsUnique = true)]
public partial class InfoCountry
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(10)]
    public string? OrderCode { get; set; }

    [Column("code")]
    [StringLength(10)]
    public string Code { get; set; } = null!;

    [Column("text_code")]
    [StringLength(50)]
    public string TextCode { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

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

    [InverseProperty("Country")]
    public virtual ICollection<HlBranch> HlBranches { get; set; } = new List<HlBranch>();

    [InverseProperty("BirthCountry")]
    public virtual ICollection<HlPerson> HlPeople { get; set; } = new List<HlPerson>();

    [InverseProperty("Country")]
    public virtual ICollection<InfoContractor> InfoContractors { get; set; } = new List<InfoContractor>();

    [InverseProperty("Owner")]
    public virtual ICollection<InfoCountryTranslate> InfoCountryTranslates { get; set; } = new List<InfoCountryTranslate>();

    [InverseProperty("Country")]
    public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; } = new List<InfoOrganization>();

    [InverseProperty("Country")]
    public virtual ICollection<InfoRegion> InfoRegions { get; set; } = new List<InfoRegion>();

    [ForeignKey("StateId")]
    [InverseProperty("InfoCountries")]
    public virtual EnumState State { get; set; } = null!;
}
