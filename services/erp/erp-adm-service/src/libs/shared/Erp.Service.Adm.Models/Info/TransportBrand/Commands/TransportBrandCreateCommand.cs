using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportBrandCreateCommand : IRequest<WbHaveId<int>>
{
    public string? OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }
    public List<TransportBrandTranslateCreateUpdateCommand> Translates { get; set; } = new();
}
