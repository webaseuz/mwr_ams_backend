using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain.Entities.Sys
{
    [Table("sys_permission_sub_group")]
    public class PermissionSubGroup :
    BaseEntity<int>
    {
        public PermissionSubGroup()
        {
            Translates = new HashSet<PermissionSubGroupTranslate>();
        }

        #region Properties

        [Column("code")]
        [StringLength(100)]
        public string Code { get; set; } = null!;

        [Column("short_name")]
        [StringLength(250)]
        public string ShortName { get; set; } = null!;

        [Column("full_name")]
        [StringLength(300)]
        public string FullName { get; set; } = null!;

        [Column("group_id")]
        public int GroupId { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by")]
        public int? CreatedBy { get; set; }

        [Column("modified_at", TypeName = "timestamp without time zone")]
        public DateTime? LastModifiedAt { get; set; }

        [Column("modified_by")]
        public int? LastModifiedBy { get; set; }

        #endregion

        #region Relationships
        [ForeignKey(nameof(GroupId))]
        public virtual PermissionGroup Group { get; set; } = null!;

        [InverseProperty(nameof(PermissionSubGroupTranslate.Owner))]
        public virtual ICollection<PermissionSubGroupTranslate> Translates { get; set; } = new List<PermissionSubGroupTranslate>();

        #endregion

    }

}
