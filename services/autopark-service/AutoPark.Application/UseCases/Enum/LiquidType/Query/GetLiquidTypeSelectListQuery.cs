using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Enum;

public class GetLiquidTypeSelectListQuery :
    IRequest<SelectList<int>>
{
}
