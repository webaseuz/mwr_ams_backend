using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class GetExpenseSelectListQuery : IRequest<SelectList<long>>
{ }

