using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportSelectListDto : WbSelectListItem<int>
{
    public int Id { get; set; }
    public int TransportModelId { get; set; }
    public long? SettingId { get; set; }
}