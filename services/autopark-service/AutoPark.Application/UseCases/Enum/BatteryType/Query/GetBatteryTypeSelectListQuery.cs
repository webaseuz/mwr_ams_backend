using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.BatteryTypes;

public class GetBatteryTypeSelectListQuery :
    IRequest<SelectList<int>>
{
}

