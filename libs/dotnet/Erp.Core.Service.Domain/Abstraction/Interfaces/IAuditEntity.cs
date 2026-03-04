using WEBASE;

namespace Erp.Core.Service.Domain;

public interface IAuditEntity : IWbAuditProp
{
}

public interface IAuditTrackEntity : IAuditEntity
{
    public int? CreatedBy { get; set; }
    public int? LastModifiedBy { get; set; }
}

