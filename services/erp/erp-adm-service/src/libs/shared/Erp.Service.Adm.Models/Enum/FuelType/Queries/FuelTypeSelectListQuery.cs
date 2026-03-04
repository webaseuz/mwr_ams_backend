using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class FuelTypeSelectListQuery : IRequest<WbSelectList<int>>
{
    public long? TransportSettingId { get; set; }
}