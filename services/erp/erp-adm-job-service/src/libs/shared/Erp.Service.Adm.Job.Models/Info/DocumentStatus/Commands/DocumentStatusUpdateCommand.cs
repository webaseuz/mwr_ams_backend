using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class DocumentStatusUpdateCommand : IRequest<bool>
{
    public int Id { get; set; } 
    public string OrderCode { get; set; }
    public string Code { get; set; }    
    public int TableId { get; set; }
    
    public int StateId {  get; set; }

    public List<DocumentStatusTableDto> Tables { get;set; } = new List<DocumentStatusTableDto>();
}
