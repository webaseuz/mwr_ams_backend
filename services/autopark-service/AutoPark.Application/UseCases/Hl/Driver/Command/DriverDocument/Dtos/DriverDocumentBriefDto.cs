namespace AutoPark.Application.UseCases.Drivers;

public class DriverDocumentBriefDto
{
    public long Id { get; set; }
    public int OwnerId { get; set; }
    public int DocumentTypeId { get; set; }
    public string DocumentTypeName { get; set; }
    public string DocumentNumber { get; set; } = null!;
    public DateTime? DocumentEndOn { get; set; }
    public Guid? DocumentFileId { get; set; }
    public string DocumentFileName { get; set; } = string.Empty;
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
