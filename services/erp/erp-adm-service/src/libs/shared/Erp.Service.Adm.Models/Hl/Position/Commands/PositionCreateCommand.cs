using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class PositionCreateCommand : IRequest<WbHaveId<int>>
{
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? OrderCode { get; set; }
    public List<PositionTranslateCommand> Translates { get; set; } = new();
}
