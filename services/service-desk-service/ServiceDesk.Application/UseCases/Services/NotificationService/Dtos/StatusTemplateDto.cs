namespace ServiceDesk.Application.UseCases.NotificationServices;

public class StatusTemplateDto
{
    public StatusTemplateDto(
        string docNumber,
        string documentType,
        string changedBy,
        string branchName,
        string status)
    {
        DocNumber = docNumber;

        if (docNumber == null)
            throw new Exception($"{nameof(DocNumber)} can not be null");

        if (branchName == null)
            throw new Exception($"{nameof(BranchName)} can not be null");

        DocumentType = documentType;
        ChangedBy = changedBy;
        ChangedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        BranchName = branchName;
        Status = status;
    }
    public string DocNumber { get; set; }
	public string DocumentType { get; set; }
	public string ChangedBy { get; set; }
	public string ChangedAt { get; set; }
	public string BranchName { get; set; }
	public string Status { get; set; }
}
