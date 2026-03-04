using System.Net.Http.Headers;
using System.Text;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Job.Application;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WEBASE;

namespace Erp.Service.Adm.Job.Infrastructure;

public class KeycloakIdentityProvider : IIdentityProvider
{
    private readonly IApplicationDbContext _context;
    public KeycloakIdentityProvider(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateUserAsync(User user, string password)
    {
        var token = await GetAccessTokenAsync();
        string key = String.Empty;

        // 1. Create User
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);

            string url = $"{InfrastructureSettings.InfrastructureInstance.Idp.BaseUrl}/adm.jobin/realms/{InfrastructureSettings.InfrastructureInstance.Idp.Realm}/users";

            var userPayload = new
            {
                username = user.UserName,
                enabled = true,
                credentials = new[]
                {
                    new
                    {
                        type = "password",
                        value = password,
                        temporary = false
                    }
                },
                firstName = user.Person.FirstName,
                lastName = user.Person.LastName,
                attributes = new { locale = "", Pinfl = user.Person.Pinfl }
            };

            var jsonPayload = JsonConvert.SerializeObject(userPayload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                key = response.Headers.Location.Segments[^1];
                Console.WriteLine($"Xatolik : {responseBody}");
                // Set IdentityKey and save to database
                user.IdentityKey = key;
                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Xatolik : {responseBody}");
                return false;
            }
        }

    }

    public async Task<User> GetUserAsync(long userId)
    {
        // Get user from database to retrieve IdentityKey
        var user = await _context.Users
            .Include(u => u.Person)
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null || string.IsNullOrEmpty(user.IdentityKey))
            return null;

        var token = await GetAccessTokenAsync();

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);

            string url = $"{InfrastructureSettings.InfrastructureInstance.Idp.BaseUrl}/adm.jobin/realms/{InfrastructureSettings.InfrastructureInstance.Idp.Realm}/users/{user.IdentityKey}";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var keycloakUser = JsonConvert.DeserializeObject<dynamic>(responseBody);

                // Update user object with Keycloak data if needed
                user.UserName = keycloakUser.username;
                user.Person.FirstName = keycloakUser.firstName;
                user.Person.LastName = keycloakUser.lastName;

                return user;
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return null;
            }
        }
    }

    public async Task<bool> UpdateUserAsync(User user, string password = null)
    {
        if (string.IsNullOrEmpty(user.IdentityKey))
            return false;

        var token = await GetAccessTokenAsync();

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);

            string url = $"{InfrastructureSettings.InfrastructureInstance.Idp.BaseUrl}/adm.jobin/realms/{InfrastructureSettings.InfrastructureInstance.Idp.Realm}/users/{user.IdentityKey}";

            var userPayload = new
            {
                username = user.UserName,
                enabled = user.StateId == WbStateIdConst.ACTIVE, // Assuming StateId 1 means active
                firstName = user.Person.FirstName,
                lastName = user.Person.LastName,
                attributes = new { locale = "", Pinfl = user.Person.Pinfl }
            };

            var jsonPayload = JsonConvert.SerializeObject(userPayload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return false;
            }

            // Update password if provided
            if (!string.IsNullOrEmpty(password))
            {
                var passwordUpdated = await ResetPasswordAsync(user.IdentityKey, password, token);
                if (!passwordUpdated)
                    return false;
            }

            return true;
        }
    }

    private async Task<bool> ResetPasswordAsync(string keycloakUserId, string newPassword, KeycloakToken token)
    {
        //var token = await GetAccessTokenAsync();

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);

            string url = $"{InfrastructureSettings.InfrastructureInstance.Idp.BaseUrl}/adm.jobin/realms/{InfrastructureSettings.InfrastructureInstance.Idp.Realm}/users/{keycloakUserId}/reset-password";
            var passwordPayload = new
            {
                type = "password",
                value = newPassword,
                temporary = false
            };

            var jsonPayload = JsonConvert.SerializeObject(passwordPayload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return false;
            }
        }
    }

    private async Task<KeycloakToken> GetAccessTokenAsync()
    {
        using (var httpClient = new HttpClient())
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", InfrastructureSettings.InfrastructureInstance.Idp.ClientId),
                new KeyValuePair<string, string>("client_secret", InfrastructureSettings.InfrastructureInstance.Idp.ClientSecret)
            });

            var response = await httpClient.PostAsync($"{InfrastructureSettings.InfrastructureInstance.Idp.BaseUrl}/realms/{InfrastructureSettings.InfrastructureInstance.Idp.Realm}/protocol/openid-connect/token", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<KeycloakToken>(responseContent);
                return tokenResponse;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return null;
            }
        }
    }
}
