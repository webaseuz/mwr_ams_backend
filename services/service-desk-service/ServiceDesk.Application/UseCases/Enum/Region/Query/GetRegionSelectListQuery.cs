using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Regions;

public class GetRegionSelectListQuery :
	IRequest<SelectList<int>>
{
    public int? CountryId { get; set; }
}
