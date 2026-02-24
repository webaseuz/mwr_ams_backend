using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Nationalities;

public class NationalityDto
{
    public int Id { get; set; }
    public string WbCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int StateId { get; set; }
    public string StateName { get; set; }
    public List<NationalityTranslate> Translates { get; set; }

}
