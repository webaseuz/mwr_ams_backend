namespace AutoPark.Application.UseCases.Expenses;

public class UpdateExpenseTablesFileCommand
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; } = null!;
}
