using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Districts;

public class GetDistrictTypeSelectListQuery : IRequest<SelectList<int>>
{
	public int? RegionId { get; set; }
}

