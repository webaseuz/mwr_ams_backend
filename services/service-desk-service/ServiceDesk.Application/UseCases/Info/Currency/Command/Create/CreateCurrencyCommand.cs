using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Currencies;

public class CreateCurrencyCommand :
    IRequest<IHaveId<int>>
{
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string TextCode { get; set; } = null!;
    public Guid? PictureId { get; set; }
    public bool IsMain { get; set; }

    public List<CurrencyTranslateCommand> Translates { get; set; } = new();
}
