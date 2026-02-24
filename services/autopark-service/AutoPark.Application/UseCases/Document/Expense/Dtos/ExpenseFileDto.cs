
namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseFileDto
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; }
}
