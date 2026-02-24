using AutoPark.Application.Security;
using AutoPark.Application.UseCases.PresentTrackingInfos;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace AutoPark.WebApi.Extensions;

public class TrackingInfoHub : Hub
{
    private static readonly ConcurrentDictionary<string, long> ConnectedUsers = new();
    private readonly IAsyncAppAuthService _authService;

    public TrackingInfoHub(IAsyncAppAuthService authService)
    {
        _authService = authService;
    }

    public async override Task OnConnectedAsync()
    {
        // get token from query string
        var token = Context.GetHttpContext()?.Request.Query["access_token"].ToString();

        // check if token is null or empty
        if (string.IsNullOrEmpty(token))
        {
            Context.Abort();
            return;
        }

        // validate token and get user
        var user = await _authService.GetUserAsync(token);

        // check if user is null
        if (user != null)
        {
            // check if user is already connected
            ConnectedUsers[Context.ConnectionId] = user.PersonId;
            await base.OnConnectedAsync();

            return;
        }

        Context.Abort();
    }
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        ConnectedUsers.TryRemove(Context.ConnectionId, out _);
        await base.OnDisconnectedAsync(exception);
    }
    public async Task SendMessage(CreatePresentTrackingInfoCommand presentTrackingInfoCommand)
    {
        await Clients.All.SendAsync("ReceiveMessage", presentTrackingInfoCommand);
    }
}
