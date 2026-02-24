using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Positions;

public class CreatePositionCommand :
	IRequest<IHaveId<int>>
{
	public string ShortName { get; set; } = null!;
	public string FullName { get; set; } = null!;
	public string Code { get; set; } = null!;
	public string OrderCode { get; set; }
	public List<PositionTranslateCommand> Translates { get; set; } = new();
}
