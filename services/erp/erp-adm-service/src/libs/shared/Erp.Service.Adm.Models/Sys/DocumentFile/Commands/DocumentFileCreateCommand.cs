using MediatR;

namespace Erp.Service.Adm.Models;

public class DocumentFileCreateCommand : IRequest
{
    public int TableId { get; set; }
    public long DocumentId { get; set; }
    public int LinkTypeId { get; set; }
    public int DownloadFromTypeId { get; set; }
    public List<DocumentFileCreateDto> Files { get; set; }
}

public class DocumentFileCreateDto
{
    public Guid Id { get; set; }
    public int FileConfigId { get; set; }
    public string ColumnName { get; set; }
    public string FileName { get; set; }
}
