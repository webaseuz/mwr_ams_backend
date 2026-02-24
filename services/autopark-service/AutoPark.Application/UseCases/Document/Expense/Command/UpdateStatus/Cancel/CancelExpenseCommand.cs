using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class CancelExpenseCommand :
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
}
