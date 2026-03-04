using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class DistrictGroupSelectListDto : WbSelectListItem<int>
{
    public int Id { get; set; }
    public string Code { get; set; } = default!;
    public string NameUzLatn { get; set; } = default!;
    public string NameRu { get; set; } = default!;
    public string NameUzCyrl { get; set; } = default!;
    public string NameEn { get; set; } = default!;

}
