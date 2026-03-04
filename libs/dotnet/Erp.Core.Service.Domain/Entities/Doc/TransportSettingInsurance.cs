using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Erp.Core.Service.Domain;

[Table("doc_transport_setting_insurance")]
public class TransportSettingInsurance :
    BaseEntity<long>
{
    #region Properties

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("insurance_type_id")]
    public int InsuranceTypeId { get; set; }

    [Column("ins_number")]
    [StringLength(50)]
    public string InsNumber { get; set; } = null!;

    [Column("expire_at")]
    public DateTime ExpireAt { get; set; }

    [Column("contractor_id")]
    public long ContractorId { get; set; }

    [Column("responsible_person_id")]
    public long ResponsiblePersonId { get; set; }

    [Column("details")]
    public string Details { get; set; }

    [Column("notify_before_day")]
    public int NotifyBeforeDay { get; set; }

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
    [ForeignKey(nameof(ContractorId))]
    public virtual Contractor Contractor { get; set; } = null!;

    [ForeignKey(nameof(InsuranceTypeId))]
    public virtual InsuranceType InsuranceType { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual TransportSetting Owner { get; set; } = null!;

    [ForeignKey(nameof(ResponsiblePersonId))]
    public virtual Person ResponsiblePerson { get; set; } = null!;

    #endregion

}
