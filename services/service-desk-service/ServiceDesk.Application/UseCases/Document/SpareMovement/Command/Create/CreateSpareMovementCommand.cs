using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class CreateSpareMovementCommand :
    IRequest<IHaveId<long>>
{
    public DateTime DocDate { get; set; }
    public int MovementTypeId { get; set; }
	public int? FromBranchId { get; set; }
	public int? ToBranchId { get; set; }
	public List<CreateSpareMovementTableCommand> Tables { get; set; } = new();
}
