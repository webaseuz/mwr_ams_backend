using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class GetExpenseQuery :
    IRequest<ExpenseDto>
{ }
