using MediatR;

namespace Erp.Service.Adm.Models;

public class NationalityUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string? WbCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public bool IsNationality { get; set; }
    public int StateId { get; set; }
    public List<NationalityTranslateCreateUpdateCommand> Translates { get; set; } = new();
}
