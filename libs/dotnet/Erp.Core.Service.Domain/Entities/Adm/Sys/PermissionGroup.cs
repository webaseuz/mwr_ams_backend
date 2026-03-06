using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain.Entities.Sys
{
    [Table("sys_permission_group", Schema = "adm")]
    public class PermissionGroup :
    BaseEntity<int>
    {
        public PermissionGroup()
        {
            Translates = new HashSet<PermissionGroupTranslate>();
        }

        #region Properties

        [Column("order_code")]
        [StringLength(50)]
        public string OrderCode { get; set; }

        [Column("short_name")]
        [StringLength(250)]
        public string ShortName { get; set; } = null!;

        [Column("full_name")]
        [StringLength(300)]
        public string FullName { get; set; } = null!;

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime? CreatedAt { get; set; }

        #endregion

        #region Relationships
        [InverseProperty(nameof(PermissionGroupTranslate.Owner))]
        public virtual ICollection<PermissionGroupTranslate> Translates { get; set; } = new List<PermissionGroupTranslate>();

        #endregion

    }
}
