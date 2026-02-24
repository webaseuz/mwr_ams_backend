namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class ServiceApplicationFileDto
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; }
}
