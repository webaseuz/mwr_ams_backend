using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class NationalityCreateCommand : IRequest<WbHaveId<int>>
{
    public string? WbCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public bool IsNationality { get; set; }
    public int StateId { get; set; }
    public List<NationalityTranslateCreateUpdateCommand> Translates { get; set; } = new();
}
