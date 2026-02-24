using Bms.WEBASE.Helpers;
using Newtonsoft.Json;

namespace ServiceDesk.Application.UseCases.Accounts;

public class TokenResultDto
{
    public string AccessToken { get; set; }
    
    [JsonConverter(typeof(WbDateTimeConverter))]
    public DateTime AccessTokenExpireAt { get; set; }
    
    public string RefreshToken { get; set; }

    [JsonConverter(typeof(WbDateTimeConverter))]
    public DateTime RefreshTokenExpireAt { get; set; }
}
