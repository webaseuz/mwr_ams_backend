namespace Erp.Service.Adm.Models;

public class DriverDocumentUpdateCommand
{
    public long Id { get; set; }
    public int DocumentTypeId { get; set; }
    public string DocumentNumber { get; set; } = null!;
    public DateTime? DocumentEndOn { get; set; }
    public Guid? DocumentFileId { get; set; }
    public string DocumentFileName { get; set; }
}
