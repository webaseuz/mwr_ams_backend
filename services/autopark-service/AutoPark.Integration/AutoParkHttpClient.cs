using AutoPark.Integration.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static System.Net.WebRequestMethods;

namespace AutoPark.Integration;

public class AutoParkHttpClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly AutoParkHttpConfig _config;

    public HttpClient HttpClient { get => _httpClient; }

    public AutoParkHttpClient(HttpClient httpClient, AutoParkHttpConfig config)
    {
        _config = config;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(_config.Api);
        _httpClient.Timeout = TimeSpan.FromSeconds(30);
    }

    public async Task<ApiResult<TResponse>> SendAsync<TResponse>(HttpMethod method, string uri,
        CancellationToken cancellationToken = default)
    {
        var httpRequestMessage = new HttpRequestMessage(method, uri);
        SetDefaultHeaders(httpRequestMessage);

        var response = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);
        var result = new ApiResult<TResponse>
        {
            IsSuccess = response.IsSuccessStatusCode,
            HttpStatus = (int)response.StatusCode
        };

        result.ResponseAsString = await response.Content.ReadAsStringAsync(cancellationToken);

        if (result.IsSuccess && !string.IsNullOrEmpty(result.ResponseAsString))
            result.Response = JsonConvert.DeserializeObject<TResponse>(result.ResponseAsString)!;

        return result;
    }

    public async Task<ApiResult<TResponse>> SendAsync<TResponse>(
                                                                    HttpMethod method,
                                                                    string uri,
                                                                    HttpContent content = null,
                                                                    CancellationToken cancellationToken = default)
    {
        var httpRequestMessage = new HttpRequestMessage(method, uri);

        if (content != null)
            httpRequestMessage.Content = content;

        SetDefaultHeaders(httpRequestMessage);

        var response = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);

        var result = new ApiResult<TResponse>
        {
            IsSuccess = response.IsSuccessStatusCode,
            HttpStatus = (int)response.StatusCode,
            ResponseAsString = await response.Content.ReadAsStringAsync(cancellationToken)
        };

        if (result.IsSuccess && !string.IsNullOrWhiteSpace(result.ResponseAsString))
            result.Response = JsonConvert.DeserializeObject<TResponse>(result.ResponseAsString)!;

        return result;
    }


    public async Task<ApiResult<TResponse>> SendAsync<TResponse, TRequest>(HttpMethod method, string uri, TRequest requestDto,
        CancellationToken cancellationToken = default)
        where TRequest : class
    {
        var httpRequestMessage = new HttpRequestMessage(method, uri);
        SetDefaultHeaders(httpRequestMessage);

        httpRequestMessage.Content = CreateContent(requestDto);
        var response = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);
        var result = new ApiResult<TResponse>
        {
            IsSuccess = response.IsSuccessStatusCode,
            HttpStatus = (int)response.StatusCode
        };

        result.ResponseAsString = await response.Content.ReadAsStringAsync(cancellationToken);

        if (result.IsSuccess && !string.IsNullOrEmpty(result.ResponseAsString))
            result.Response = JsonConvert.DeserializeObject<TResponse>(result.ResponseAsString)!;

        return result;
    }

    public static HttpContent CreateContent<T>(T dto)
    {
        try
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string json = JsonConvert.SerializeObject(dto, settings);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        catch (Exception ex)
        {
            Console.Write($"Model: {dto} : {ex.InnerException}");
            return null;
        }
    }

    private void SetDefaultHeaders(HttpRequestMessage requestMessage)
    {
        string token = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_config.UserName}:{_config.Password}"));
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", token);
    }
    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
