namespace Erp.Service.Adm.Models;

public class CustomJobBriefDto
{
    public long Id { get; set; }
    public int JobTypeId { get; set; }
    public string JobType { get; set; }
    public bool IsForceUpdate { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public string BackgroundJobId { get; set; }
    public string ExtendData { get; set; }
    public int TotalCount { get; set; }
    public int SuccessCount { get; set; }
    public int ErrorCount { get; set; }
    public string Error { get; set; }

    public int OrganizationId { get; set; }
    public string Organization { get; set; }

    public int RegionId { get; set; }
    public string Region { get; set; }

    public int DistrictId { get; set; }
    public string District { get; set; }

    public int StatusId { get; set; }
    public string Status { get; set; }

    public int CacheCount { get; set; }

    public int PrevStatusId { get; set; }
    public string PrevStatus { get; set; }

    public string Message { get; set; }
    public bool CanApprove { get; set; }
    public bool CanEdit { get; set; }
    public bool CanDelete { get; set; }
}
