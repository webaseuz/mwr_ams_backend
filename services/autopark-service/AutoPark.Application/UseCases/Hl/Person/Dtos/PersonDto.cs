namespace AutoPark.Application.UseCases.Persons;

public class PersonDto
{
    public long Id { get; set; }
    public string Pinfl { get; set; }
    public string Inn { get; set; }
    public int DocumentTypeId { get; set; }
    public string DocumentTypeName { get; set; }
    public string DocumentSeria { get; set; } = null!;
    public string DocumentNumber { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string FullName { get; set; }
    public string MiddleName { get; set; }
    public int? GenderId { get; set; }
    public string GenderName { get; set; }
    public int? BirthCountryId { get; set; }
    public string BirthCountryName { get; set; }
    public int? BirthRegionId { get; set; }
    public string BirthRegionName { get; set; }
    public int? BirthDistrictId { get; set; }
    public string BirthDistrictName { get; set; }
    public int? CitizenshipId { get; set; }
    public string CitizenshipName { get; set; }
    public int? LivingRegionId { get; set; }
    public string LivingRegionName { get; set; }
    public int? LivingDistrictId { get; set; }
    public string LivingDistrictName { get; set; }
    public int? BranchId { get; set; }
    public string BranchName { get; set; }
    public Guid? FileId { get; set; }
    public string FileName { get; set; }
    public DateTime BirthOn { get; set; }
}
