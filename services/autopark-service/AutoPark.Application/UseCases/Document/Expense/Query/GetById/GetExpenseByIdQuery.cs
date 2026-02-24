using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class GetExpenseByIdQuery :
    IRequest<ExpenseDto>
{
    public long Id { get; set; }
}
