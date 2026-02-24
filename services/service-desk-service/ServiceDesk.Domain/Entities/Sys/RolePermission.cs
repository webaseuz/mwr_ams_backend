using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain.Entities.Sys
{
    [Table("sys_role_permission")]
    public class RolePermission
        : IHaveIdProp<int>,
		IHaveSingleUniqueForeignKey<int>

	{
        #region Properties
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [Column("permission_id")]
        public int PermissionId { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("created_by")]
        public int CreatedBy { get; set; }

        [Column("modified_by")]
        public int? ModifiedBy { get; set; }

        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; }

        #endregion

        #region Relationships
        [ForeignKey(nameof(PermissionId))]
        public virtual Permission Permission { get; set; } = null!;

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; } = null!;
        #endregion 

        #region Methods
     
		public object GetUniqueForeignKey() => PermissionId;
		public void SetUniqueForeignKey(int foreignKey) => PermissionId = foreignKey;

		#endregion
	}
}
