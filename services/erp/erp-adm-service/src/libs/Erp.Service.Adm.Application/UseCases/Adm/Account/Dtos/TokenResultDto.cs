using Erp.Core.Extensions;
using Newtonsoft.Json;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public class TokenResultDto
{
    public string AccessToken { get; set; }

    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime AccessTokenExpireAt { get; set; }

    public string RefreshToken { get; set; }

    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime RefreshTokenExpireAt { get; set; }
}
