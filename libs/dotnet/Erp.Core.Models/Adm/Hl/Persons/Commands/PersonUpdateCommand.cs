using MediatR;

namespace Erp.Core.Sdk.Models;
public class PersonUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public int GenderId { get; set; }
    public DateTime BirthOn { get; set; }
    public string Pinfl { get; set; }
    public string DocSeria { get; set; }
    public string DocNumber { get; set; }
    public string DocExprireOrganization { get; set; }
    public string PhoneNumber { get; set; }
    public string BirthPlace { get; set; }
    public int StateId { get; set; } = 1;
    public int? CitizenshipId { get; set; }
    public int? NationalityId { get; set; }
    public int DocumentTypeId { get; set; }
    public int? BirthCountryId { get; set; }
    public DateTime? DeathDate { get; set; }
    public DateTime? DocExpireDate { get; set; }
    public DateTime DocIssueDate { get; set; }
    public bool IsDeath { get; set; }
}
