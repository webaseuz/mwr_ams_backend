namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class UpdateServiceApplicationFileCommand
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; } = null!;
}
