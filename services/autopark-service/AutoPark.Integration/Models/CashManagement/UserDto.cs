namespace AutoPark.Integration.Models;

public class UserDto
{
    public Guid UserId { get; set; }
    public string TableCode { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Inn { get; set; } = string.Empty;
    public string Pinfl { get; set; } = string.Empty;
    // [JsonConverter(typeof(JsonDateConverter))]
    public DateTime BirthDate { get; set; }
    public string BirthPlace { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PassportSeria { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty;
    //[JsonConverter(typeof(JsonDateConverter))]
    public DateTime PassportDateEnd { get; set; }
    //[JsonConverter(typeof(JsonDateConverter))]
    public DateTime PassportDateBegin { get; set; }
    public string PassportIssued { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
}
