namespace AutoPark.Application.UseCases.Expenses;

public class CreateExpenseTablesFileCommand
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; }
}
