namespace ServiceDesk.Application.UseCases.Services.SpareTurnoverServices;

public class RemoveSpareTurnoverRowDto
{
    public RemoveSpareTurnoverRowDto(int tableId,
                                     long documentId)
    {
        TableId = tableId;
        DocumentId = documentId;
    }
    public int TableId { get; set; }
    public long DocumentId { get; set; }
}
