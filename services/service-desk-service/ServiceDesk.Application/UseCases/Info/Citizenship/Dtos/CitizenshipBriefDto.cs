namespace ServiceDesk.Application.UseCases.Citizenships;

public class CitizenshipBriefDto
{
    public int Id { get; set; }
    public string WbCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int StateId { get; set; }
    public string StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
