using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Persons;

public class CreatePersonCommand :
    IRequest<IHaveId<long>>
{
    public string Pinfl { get; set; }
    public string Inn { get; set; }
    public int DocumentTypeId { get; set; }
    public DateTime BirthOn { get; set; }
    public string DocumentSeria { get; set; } = null!;
    public string DocumentNumber { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; }
    public int? GenderId { get; set; }
    public int? BirthCountryId { get; set; }
    public int? BirthRegionId { get; set; }
    public int? BirthDistrictId { get; set; }
    public int? CitizenshipId { get; set; }
    public int? LivingRegionId { get; set; }
    public int? LivingDistrictId { get; set; }
    public Guid? FileId { get; set; }
    public string FileName { get; set; }
}
