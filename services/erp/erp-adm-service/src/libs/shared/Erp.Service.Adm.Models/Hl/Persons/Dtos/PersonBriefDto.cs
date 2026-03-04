using System.Text.Json.Serialization;
using Erp.Core.Extensions;

namespace Erp.Service.Adm.Models;
public class PersonBriefDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }

   // [JsonConverter(typeof(CustomDateTimeNullableConverter))]
    public DateTime? BirthOn { get; set; }
    public string Pinfl { get; set; }
}
