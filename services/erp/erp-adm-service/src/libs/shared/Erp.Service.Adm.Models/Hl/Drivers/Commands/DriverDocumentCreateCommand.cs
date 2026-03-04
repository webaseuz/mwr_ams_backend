namespace Erp.Service.Adm.Models;

public class DriverDocumentCreateCommand
{
    public int DocumentTypeId { get; set; }
    public string DocumentNumber { get; set; } = null!;
    public Guid? DocumentFileId { get; set; }
    public string DocumentFileName { get; set; }
    public DateTime? DocumentEndOn { get; set; }
}
