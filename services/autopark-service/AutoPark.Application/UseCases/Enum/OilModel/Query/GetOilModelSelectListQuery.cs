using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.OilModels;

public class GetOilModelSelectListQuery :
    IRequest<SelectList<int>>
{
    public int? OilTypeId { get; set; }
}
