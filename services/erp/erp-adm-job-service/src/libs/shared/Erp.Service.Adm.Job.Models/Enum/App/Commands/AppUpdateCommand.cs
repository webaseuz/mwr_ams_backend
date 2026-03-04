using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class AppUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string AppUrl { get; set; }
    public string AppIcon { get; set; }
    public string Description { get; set; }
    public int StateId { get; set; }
    public List<AppTranslateCreateUpdateCommand> Translates { get; set; } = new List<AppTranslateCreateUpdateCommand>();
}
