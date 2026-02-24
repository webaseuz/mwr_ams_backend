using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("doc_service_application")]
[Index("StatusId", "DeviceId", Name = "indx__doc_ser_app__stid_devid")]
public partial class DocServiceApplication
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("doc_number")]
    [StringLength(50)]
    public string DocNumber { get; set; } = null!;

    [Column("doc_date")]
    public DateTime DocDate { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("device_id")]
    public int DeviceId { get; set; }

    [Column("executor_type_id")]
    public int ExecutorTypeId { get; set; }

    [Column("service_contractor_id")]
    public long? ServiceContractorId { get; set; }

    [Column("responsible_person_id")]
    public long ResponsiblePersonId { get; set; }

    [Column("phone_number")]
    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    [Column("process_duration")]
    public int? ProcessDuration { get; set; }

    [Column("end_at", TypeName = "timestamp without time zone")]
    public DateTime? EndAt { get; set; }

    [Column("application_desc")]
    public string? ApplicationDesc { get; set; }

    [Column("problem_desc")]
    public string? ProblemDesc { get; set; }

    [Column("executor_comment")]
    public string? ExecutorComment { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("DocServiceApplications")]
    public virtual HlBranch Branch { get; set; } = null!;

    [ForeignKey("DeviceId")]
    [InverseProperty("DocServiceApplications")]
    public virtual HlDevice Device { get; set; } = null!;

    [InverseProperty("Owner")]
    public virtual ICollection<DocServiceApplicationExecutorFile> DocServiceApplicationExecutorFiles { get; set; } = new List<DocServiceApplicationExecutorFile>();

    [InverseProperty("Owner")]
    public virtual ICollection<DocServiceApplicationFile> DocServiceApplicationFiles { get; set; } = new List<DocServiceApplicationFile>();

    [InverseProperty("Owner")]
    public virtual ICollection<DocServiceApplicationHistory> DocServiceApplicationHistories { get; set; } = new List<DocServiceApplicationHistory>();

    [InverseProperty("Owner")]
    public virtual ICollection<DocServiceApplicationPart> DocServiceApplicationParts { get; set; } = new List<DocServiceApplicationPart>();

    [ForeignKey("ExecutorTypeId")]
    [InverseProperty("DocServiceApplications")]
    public virtual EnumExecutorType ExecutorType { get; set; } = null!;

    [ForeignKey("ResponsiblePersonId")]
    [InverseProperty("DocServiceApplications")]
    public virtual HlPerson ResponsiblePerson { get; set; } = null!;

    [ForeignKey("ServiceContractorId")]
    [InverseProperty("DocServiceApplications")]
    public virtual InfoContractor? ServiceContractor { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("DocServiceApplications")]
    public virtual EnumStatus Status { get; set; } = null!;
}
