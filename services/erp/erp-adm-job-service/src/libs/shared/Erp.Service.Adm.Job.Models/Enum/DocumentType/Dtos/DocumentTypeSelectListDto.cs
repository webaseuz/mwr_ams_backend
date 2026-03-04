using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class DocumentTypeSelectListDto : WbSelectListItem<int>
{
    public int Id { get; set; }
    public string NameUz { get; set; } = null!;
    public string NameRu { get; set; } = null!;
    public string NameUzCyrl { get; set; } = null!;
    public string NameEn { get; set; } = null!;
    public int StateId { get; set; }
    public string State { get; set; }

}
