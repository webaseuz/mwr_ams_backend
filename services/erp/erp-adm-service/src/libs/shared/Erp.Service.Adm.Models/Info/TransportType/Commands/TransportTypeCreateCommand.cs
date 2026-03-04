using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportTypeCreateCommand : IRequest<WbHaveId<int>>
{
    public string? OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }
    public List<TransportTypeTranslateCreateUpdateCommand> Translates { get; set; } = new();
}
