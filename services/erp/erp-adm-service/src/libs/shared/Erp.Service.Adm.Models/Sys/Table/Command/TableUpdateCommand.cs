using MediatR;

namespace Erp.Service.Adm.Models;

public class TableUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public List<FileConfigUpdateCommand> FileConfigs { get; set; } = new();
    public List<TableTranslateCommand> Translates { get; set; } = new();
}
