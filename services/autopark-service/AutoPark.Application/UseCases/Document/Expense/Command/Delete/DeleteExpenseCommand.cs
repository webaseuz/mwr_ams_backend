using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class DeleteExpenseCommand :
    IRequest<SuccessResult<bool>>
{
    public long Id { get; set; }
}
