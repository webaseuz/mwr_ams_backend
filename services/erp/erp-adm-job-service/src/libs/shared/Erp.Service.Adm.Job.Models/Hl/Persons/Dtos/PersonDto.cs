namespace Erp.Service.Adm.Job.Models;
public class PersonDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public string Pinfl { get; set; }
    public string DocSeria { get; set; }
    public string DocNumber { get; set; }
    public string DocExprireOrganization { get; set; }
    public string PhoneNumber { get; set; }
    public string BirthPlace { get; set; }
    public string NameOrder { get; set; }
    public int GenderId { get; set; }
    public string Gender { get; set; }
    public int StateId { get; set; }
    public int? CitizenshipId { get; set; }
    public string Citizenship { get; set; }
    public int? NationalityId { get; set; }
    public string Nationality { get; set; }
    public int? LivingCountryId { get; set; }
    public string LivingCountry { get; set; }
    public int? LivingRegionId { get; set; }
    public string LivingRegion { get; set; }
    public int? LivingDistrictId { get; set; }
    public string LivingDistrict { get; set; }
    public int? LivingMfyId { get; set; }
    public string LivingMfy { get; set; }
    public string LivingAddress { get; set; }
    public int DocumentTypeId { get; set; }
    public int? BirthCountryId { get; set; }
    public string BirthCountry { get; set; }
    public DateTime? DeathDate { get; set; }
    public DateTime? DocExpireDate { get; set; }
    public DateTime DocIssueDate { get; set; }
    public DateTime BirthOn { get; set; }
    public bool IsDeath { get; set; }

    public string Photo { get; set; }
}
