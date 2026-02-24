using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Application.UseCases.Report;

[Keyless]
public class ExpenseReportList
{
    [Column("expense_date")]
    public DateTime ExpenseDate { get; set; }
    [Column("expense_type_id")]
    public int ExpenseTypeId { get; set; }
    [Column("brand")]
    public string Brand { get; set; }
    [Column("quantity")]
    public decimal Quantity { get; set; }
    [Column("price")]
    public decimal Price { get; set; }
    [Column("expense_price")]
    public decimal ExpensePrice { get; set; }
}

public class ExpenseReportListDto
{
    public DateTime ExpenseDate { get; set; }
    public string ExpenseType { get; set; }
    public string Type { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal ExpensePrice { get; set; }
}