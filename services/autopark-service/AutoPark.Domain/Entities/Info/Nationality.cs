using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_nationality")]
public class Nationality :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public Nationality()
    {
        Translates = new HashSet<NationalityTranslate>();
    }

    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("wb_code")]
    [StringLength(50)]
    public string WbCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;
    [Column("is_nationality")]
    public bool IsNationality { get; set; }

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
    [InverseProperty(nameof(NationalityTranslate.Owner))]
    public virtual ICollection<NationalityTranslate> Translates { get; set; } = new List<NationalityTranslate>();

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
