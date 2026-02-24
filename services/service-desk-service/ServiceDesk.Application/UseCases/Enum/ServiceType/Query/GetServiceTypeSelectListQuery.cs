using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class GetServiceTypeSelectListQuery : IRequest<SelectList<int>>
{ 
    public int? DeviceTypeId { get; set; }
}
