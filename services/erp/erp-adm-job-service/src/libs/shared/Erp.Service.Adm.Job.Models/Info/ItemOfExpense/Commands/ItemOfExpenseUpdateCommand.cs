using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class ItemOfExpenseUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int IsGroup { get; set; }
    public int? ParentId { get; set; }
    public int StateId { get; set; }
    public int Level { get; set; }

    public List<ItemOfExpenseTranslateCreateUpdateCommand> Translates { get; set; } = new List<ItemOfExpenseTranslateCreateUpdateCommand>();

}
