using Newtonsoft.Json;

namespace Erp.Service.Adm.Job.Infrastructure;

public class KeycloakToken
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("expires_in")]
    public double ExpiresIn { get; set; }

    [JsonProperty("refresh_expires_in")]
    public double RefreshExpiresIn { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get; set; }

    [JsonProperty("scope")]
    public string Scope { get; set; }
}
