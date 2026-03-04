using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class PersonCreateCommand : IRequest<WbHaveId<int>>
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
    public DateTime DocIssueDate { get; set; }
    public DateTime? DocExpireDate { get; set; }
    public string BirthPlace { get; set; }
    public DateTime BirthOn { get; set; }
    public int GenderId { get; set; }
    public int? CitizenshipId { get; set; }
    public string Citizenship { get; set; }
    public int? NationalityId { get; set; }
    public string Nationality { get; set; }
    public int DocumentTypeId { get; set; }
    public int? BirthCountryId { get; set; }
    public string BirthCountry { get; set; }
    public string PhoneNumber { get; set; }
    public int StateId { get; set; } = WbStateIdConst.ACTIVE;
    public bool IsDeath { get; set; }
    public DateTime? DeathDate { get; set; }
    public string DocExprireOrganization { get; set; }
}

