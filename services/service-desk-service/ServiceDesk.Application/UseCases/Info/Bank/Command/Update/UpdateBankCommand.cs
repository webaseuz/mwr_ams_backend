using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Banks;

public class UpdateBankCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string BankCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }

    public List<BankTranslateCommand> Translates { get; set; } = new();
}