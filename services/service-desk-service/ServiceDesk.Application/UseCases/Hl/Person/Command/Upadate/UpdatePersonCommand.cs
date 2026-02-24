using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Persons;

public class UpdatePersonCommand :
     IHaveIdProp<long>,
        IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public string Pinfl { get; set; }
    public string Inn { get; set; }
    public int DocumentTypeId { get; set; }
    public DateTime BirthOn { get; set; }
    public string DocumentSeria { get; set; }
    public string DocumentNumber { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string FullName { get; private set; }
    public string MiddleName { get; set; }
    public int? GenderId { get; set; }
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
    public Guid? FileId { get; set; }
    public string FileName { get; set; }
}
