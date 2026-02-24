using MediatR;

namespace ServiceDesk.Application.UseCases.SpareMovements;
public class CreateSpareMovementTableCommand :
	IRequest<long>
{
	public int DeviceSpareTypeId { get; set; }
	public int Quantity { get; set; }
}
