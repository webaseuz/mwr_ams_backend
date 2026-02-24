using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class UpdateSpareMovementCommand :
    IRequest<IHaveId<long>>
{
	public long Id { get; set; }
    public DateTime DocDate { get; set; }
    public int MovementTypeId { get; set; }
	public int? FromBranchId { get; set; }
	public int? ToBranchId { get; set; }
	public List<UpdateSpareMovementTableCommand> Tables { get; set; } = new();
}
