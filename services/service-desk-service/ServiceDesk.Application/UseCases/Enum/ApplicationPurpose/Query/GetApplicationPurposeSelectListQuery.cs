using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ApplicationPurposes;

public class GetApplicationPurposeSelectListQuery : IRequest<SelectList<int>>
{
    public int? DeviceTypeId { get; set; }
}

