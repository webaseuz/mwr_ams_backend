using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Regions;

public class DeleteRegionCommand :
	IRequest<SuccessResult<bool>>
{
	public int Id { get; set; }
}
