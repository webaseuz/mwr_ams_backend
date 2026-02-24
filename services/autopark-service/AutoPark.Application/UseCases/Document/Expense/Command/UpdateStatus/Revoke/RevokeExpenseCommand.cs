using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class RevokeExpenseCommand :
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
}