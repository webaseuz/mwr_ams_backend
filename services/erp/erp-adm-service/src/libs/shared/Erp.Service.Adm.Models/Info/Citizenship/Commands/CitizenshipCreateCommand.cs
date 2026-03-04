using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class CitizenshipCreateCommand : IRequest<WbHaveId<int>>
{
    public string? WbCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public bool IsCitizenship { get; set; }
    public int StateId { get; set; }
    public List<CitizenshipTranslateCreateUpdateCommand> Translates { get; set; } = new();
}
