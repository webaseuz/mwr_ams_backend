namespace WEBASE.Security.Abstraction;

public class TokenResult
{
    public string Token { get; set; }
    public DateTime ExpireAt { get; set; }
}