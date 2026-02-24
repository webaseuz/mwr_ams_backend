using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Positions;

public class DeletePositionCommand :
	IRequest<SuccessResult<bool>>
{
	public int Id { get; set; }
}
