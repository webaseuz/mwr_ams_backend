using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.BaseDeviceTypes;

public class GetBaseDeviceTypeSelectListQuery : IRequest<SelectList<int>>
{
}

