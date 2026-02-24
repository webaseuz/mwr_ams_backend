using AutoPark.Application.UseCases.Accounts;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AutoPark.XUnitTests;

public class AuthenticatedTestBase
    : IClassFixture<CustomWebApiFactory>
{
    protected readonly HttpClient ClientRealDb;
    private static string? _token;
    public AuthenticatedTestBase(CustomWebApiFactory factorygGetToken)
    {
        ClientRealDb = factorygGetToken.CreateClient();
        AuthenticateAsync().GetAwaiter().GetResult();
    }

    private async Task AuthenticateAsync()
    {
        if (!string.IsNullOrEmpty(_token))
        {
            ClientRealDb.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            return;
        }

        var loginRequest = new
        {
            userIdentity = "admin",
            password = "123456"
        };

        var response = await ClientRealDb.PostAsJsonAsync("/Account/GenerateToken", loginRequest);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TokenResultDto>(json);

        _token = result?.AccessToken ?? throw new Exception("Token olishda xatolik!");

        ClientRealDb.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
    }
}
