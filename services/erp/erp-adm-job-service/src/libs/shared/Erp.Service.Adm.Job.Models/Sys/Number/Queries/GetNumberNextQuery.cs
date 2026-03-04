using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class GetNumberNextQuery : IRequest<GetNumberNextDto>
{
    public int FinanceYear { get; set; } = DateTime.Now.Year;
    public int OrganizationId { get; set; }
    public string TemplateDocument { get; set; }
    public string NumberDocument { get; set; } // null bo'lishi mumkin
    public int? ExternalSourceTypeId { get; set; }
}
