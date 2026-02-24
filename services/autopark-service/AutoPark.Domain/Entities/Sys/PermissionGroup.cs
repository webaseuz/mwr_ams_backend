using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain.Entities.Sys
{
    [Table("sys_permission_group")]
    public class PermissionGroup :
        IHaveIdProp<int>

    {
        public PermissionGroup()
        {
            Translates = new HashSet<PermissionGroupTranslate>();
        }

        #region Properties
        [Key]
        [Column("id")]
        public int Id { get; set; }

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
        public bool IsDeleted { get; private set; }

        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime? CreatedAt { get; set; }

        #endregion

        #region Relationships
        [InverseProperty(nameof(PermissionGroupTranslate.Owner))]
        public virtual ICollection<PermissionGroupTranslate> Translates { get; set; } = new List<PermissionGroupTranslate>();

        #endregion

        #region Methods
        #endregion
    }
}
