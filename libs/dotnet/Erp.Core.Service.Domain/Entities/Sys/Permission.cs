using Erp.Core.Service.Domain.Entities.Sys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("sys_permission")]
public partial class Permission :
    BaseEntity<int>
{
    public Permission()
    {
        Translates = new HashSet<PermissionTranslate>();
    }
    #region Properties

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

    [Column("code")]
    [StringLength(100)]
    public string Code { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(300)]
    public string FullName { get; set; } = null!;

    [Column("sub_group_id")]
    public int SubGroupId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;

    #endregion

    #region Relationships
    [ForeignKey(nameof(SubGroupId))]
    public virtual PermissionSubGroup SubGroup { get; set; } = null!;

    [InverseProperty(nameof(PermissionTranslate.Owner))]
    public virtual ICollection<PermissionTranslate> Translates { get; set; } = new List<PermissionTranslate>();

    #endregion

}
