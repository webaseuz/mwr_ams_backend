using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.OilTypes;

public class GetOilTypeSelectListQuery :
    IRequest<SelectList<int>>
{
}
