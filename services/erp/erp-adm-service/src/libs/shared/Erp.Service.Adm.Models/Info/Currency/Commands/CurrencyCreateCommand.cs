using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class CurrencyCreateCommand : IRequest<WbHaveId<int>>
{
    public string? OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string Code { get; set; }
    public string? TextCode { get; set; }
    public Guid? PictureId { get; set; }
    public bool IsMain { get; set; }
    public int StateId { get; set; }
    public List<CurrencyTranslateCreateUpdateCommand> Translates { get; set; } = new();
}
