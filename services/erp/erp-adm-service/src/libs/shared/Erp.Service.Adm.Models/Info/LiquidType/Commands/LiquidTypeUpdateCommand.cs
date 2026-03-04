using MediatR;

namespace Erp.Service.Adm.Models;

public class LiquidTypeUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string? OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }
    public List<LiquidTypeTranslateCreateUpdateCommand> Translates { get; set; } = new();
}
