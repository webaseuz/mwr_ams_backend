namespace AutoPark.Integration.Models;

public class UserRespDto
{
    public int Status { get; set; }
    public string Error { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public List<UserDto> Data { get; set; } = new();
}
