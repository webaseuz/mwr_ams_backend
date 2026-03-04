using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportModelFileSelectListDto : WbSelectListItem<Guid>
{
    public Guid Id { get; set; }
    public int? TransportModelId { get; set; }
    public int? TransportColorId { get; set; }
}