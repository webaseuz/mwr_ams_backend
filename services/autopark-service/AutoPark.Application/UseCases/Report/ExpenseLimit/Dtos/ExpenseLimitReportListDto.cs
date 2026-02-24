using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Application.UseCases.ExpenseLimits;

[Keyless]
public class ExpenseLimitReportList
{
    [Column("expense_type_id")]
    public int ExpenseTypeId { get; set; }
    [Column("expense_price")]
    public decimal ExpensePrice { get; set; }
    [Column("monthly_limit")]
    public decimal MonthlyLimit { get; set; }
    [Column("is_over_limit")]
    public bool IsOverLimit { get; set; }
}
public class ExpenseLimitReportListDto
{
    public string ExpenseType { get; set; }
    public decimal ExpensePrice { get; set; }
    public decimal MonthlyLimit { get; set; }
    public bool IsOverLimit { get; set; }
}