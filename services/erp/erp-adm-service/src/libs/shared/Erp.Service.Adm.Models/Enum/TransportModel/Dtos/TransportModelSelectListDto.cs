using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportModelSelectListDto : WbSelectListItem<int>
{
    public int Id { get; set; }
    public int TransportTypeId { get; set; }
}