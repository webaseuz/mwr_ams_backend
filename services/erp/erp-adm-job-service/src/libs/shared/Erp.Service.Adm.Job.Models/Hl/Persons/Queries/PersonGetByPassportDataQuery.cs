using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class PersonGetByPassportDataQuery : IRequest<PersonDto>
{
    public string Seria { get; set; }
    public string Number { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string DateOfBirthAsString { get; set; }
    public int DocumentTypeId { get; set; }
    public string Pinfl { get; set; }
    public bool IsActivePersonalData { get; set; } = false;
    public bool IsSearchAndSave { get; set; } = false;
    public bool IsActivePersonalAddress { get; set; } = false;
    public bool IncludePhoto { get; set; }
    public bool IncludeDisabilityGroup { get; set; }
    public bool IncludeAddress { get; set; }
    public bool IncludeDivorceInfo { get; set; }
    public bool IncludeMariageInfo { get; set; }
    public bool IncludeSalaryInfo { get; set; }
    public bool IncludePositionInfo { get; set; }
    public bool IncludeKadastrInfo { get; set; }
    public bool IncludeDiplomaInfo { get; set; }
    public bool IncludeAlimentInfo { get; set; }
}
