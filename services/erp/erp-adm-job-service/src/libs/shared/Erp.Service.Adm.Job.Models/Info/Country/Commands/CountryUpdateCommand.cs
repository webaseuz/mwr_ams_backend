using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class CountryUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string TextCode { get; set; }
    public string Icon { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }
    public List<CountryTranslateCreateUpdateCommand> Translates { get; set; } = new List<CountryTranslateCreateUpdateCommand>();
}
