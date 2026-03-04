using MediatR;

namespace Erp.Service.Adm.Models;

public class OilTypeUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string? OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }
    public List<OilTypeTranslateCreateUpdateCommand> Translates { get; set; } = new();
}
