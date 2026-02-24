using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class AcceptExpenseCommand :
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
}
