namespace AutoPark.Application.UseCases.Accounts;

public class UserTokenInfoDto : TokenResultDto
{
    public UserInfoDto UserInfo { get; set; } = new();
}