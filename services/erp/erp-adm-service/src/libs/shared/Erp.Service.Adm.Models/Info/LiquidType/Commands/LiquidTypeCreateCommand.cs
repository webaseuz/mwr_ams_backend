using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class LiquidTypeCreateCommand : IRequest<WbHaveId<int>>
{
    public string? OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }
    public List<LiquidTypeTranslateCreateUpdateCommand> Translates { get; set; } = new();
}
