namespace Erp.Service.Adm.Application.UseCases;

public class UserTokenInfoDto : TokenResultDto
{
    public UserInfoDto UserInfo { get; set; } = new();
}
