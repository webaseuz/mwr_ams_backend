namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class MobileAppVersionBriefDto
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = null!;
    public string VersionCode { get; set; } = null!;
    public string Details { get; set; } = null!;
    public DateTime ReleaseAt { get; set; }
    public int StateId { get; private set; }
    public string StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    #region CanActions
    public bool CanModify { get; set; }
    public bool CanDelete { get; set; }
    public bool CanView { get; set; }
    #endregion
}