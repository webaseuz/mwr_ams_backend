using AutoPark.Application.UseCases.Persons;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Drivers;

public class UpdateDriverCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public List<UpdateDriverDocumentCommand> Documents { get; set; } = new();
    public UpdatePersonCommand Person { get; set; } = null!;
}
