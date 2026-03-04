using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class BankCreateCommand : IRequest<WbHaveId<int>>
{
    public string Inn { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string BankCode { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public string Address { get; set; }
    public string Website { get; set; }
    public int StateId { get; set; }

    public List<BankTranslateCreateUpdateCommand> Translates { get; set; } = new List<BankTranslateCreateUpdateCommand>();
}
