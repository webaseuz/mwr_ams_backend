using AutoPark.Integration.Models.Yhxbb.Auth;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AutoPark.Integration.Service;

public class YhxbbHttpClient
{
    private readonly HttpClient _http;
    private readonly AutoParkHttpConfig _config;

    public YhxbbHttpClient(HttpClient http, AutoParkHttpConfig config)
    {
        _http = http;
        _config = config;
        _http.BaseAddress = new Uri(_config.Api);
        _http.Timeout = TimeSpan.FromSeconds(30);
    }

    public async Task<string> AuthenticateAsync()
    {
        var authBody = new YhxbbAuthRequest
        {
            Username = _config.UserName,
            Password = _config.Password
        };

        var response = await _http.PostAsJsonAsync(_config.Api, authBody);
        var result = await response.Content.ReadFromJsonAsync<YhxbbAuthResponse>();

        return result?.Token ?? throw new Exception("Autentifikatsiya xatosi");
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest body)
    {
        var token = await AuthenticateAsync();
        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var url = $"{_config.Api}{endpoint}";
        var response = await _http.PostAsJsonAsync(url, body);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"YHXBB error: {response.StatusCode}");

        return await response.Content.ReadFromJsonAsync<TResponse>();
    }
}