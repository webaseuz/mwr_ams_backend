using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Regions;

public class GetRegionSelectListQuery :
    IRequest<SelectList<int>>
{
    public int? CountryId { get; set; }
}
