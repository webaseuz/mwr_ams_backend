namespace AutoPark.Application.UseCases.Refuels;

public class CreateRefuelFileCommand
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; } = null!;
}
