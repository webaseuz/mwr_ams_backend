using AutoPark.Domain.Entities.Sys;
using Bms.Common.Domain.WEBASE.EF;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("sys_permission")]
public partial class Permission :
    IModule<PermissionTranslate, PermissionSubGroup, PermissionSubGroupTranslate>,
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public Permission()
    {
        Translates = new HashSet<PermissionTranslate>();
    }
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

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
    public bool IsDeleted { get; private set; }

    [Column("state_id")]
    public int StateId { get; private set; }

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;

    #endregion

    #region Relationships
    [ForeignKey(nameof(SubGroupId))]
    public virtual PermissionSubGroup SubGroup { get; set; } = null!;

    [InverseProperty(nameof(PermissionTranslate.Owner))]
    public virtual ICollection<PermissionTranslate> Translates { get; set; } = new List<PermissionTranslate>();

    #endregion

    #region Methods
    public void MarkAsActive()
        => StateId = StateIdConst.ACTIVE;
    public void MarkAsPassive()
        => StateId = StateIdConst.PASSIVE;
    #endregion
}
