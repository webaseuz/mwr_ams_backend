using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class RegionUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string RegionCode { get; set; }
    public string Code { get; set; }
    public string SoatoCode { get; set; }
    public int CountryId { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }

    public List<RegionTranslateCreateUpdateCommand> Translates { get; set; } = new List<RegionTranslateCreateUpdateCommand>();
}
