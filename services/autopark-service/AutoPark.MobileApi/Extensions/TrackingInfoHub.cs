using AutoPark.Application;
using AutoPark.Application.Security;
using AutoPark.Application.UseCases.PresentTrackingInfos;
using AutoPark.Application.UseCases.TrackingInfos;
using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace AutoPark.MobileApi.Extensions;

public class TrackingInfoHub : Hub
{
    private static readonly ConcurrentDictionary<string, long> ConnectedUsers = new();
    private readonly IAsyncAppAuthService _authService;
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public TrackingInfoHub(IAsyncAppAuthService authService, IWriteEfCoreContext context, IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
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
    public async Task SendMessage(CreatePresentTrackingInfoCommand infoCommand)
    {
        // ConnectedUsers user get personId 
        var personId = ConnectedUsers[Context.ConnectionId];

        var resultPresentTrackingInfo = await CreatePresentTracingInfo(infoCommand, personId, CancellationToken.None);

        if (!resultPresentTrackingInfo.Success)
            throw new Exception("Error while creating present tracking info");

        var resultTrackingInfo = await CreateTracingInfo(new CreateTrackingInfoCommand()
        {
            Latitude = infoCommand.Latitude,
            Longitude = infoCommand.Longitude,
            PersonId = personId,
            DateAt = DateTime.Now
        }, CancellationToken.None);

        if (!resultTrackingInfo.Success)
            throw new Exception("Error while creating tracking info");

        await Clients.All.SendAsync("ReceiveMessage", infoCommand);
    }

    private async Task<SuccessResult<bool>> CreatePresentTracingInfo(CreatePresentTrackingInfoCommand createTrackingInfo,
                                                                     long personId,
                                                                    CancellationToken cancellationToken)
    {
        var entity = createTrackingInfo.CreateEntity<CreatePresentTrackingInfoCommand, PresentTrackingInfo>(_mapper);

        entity.PersonId = personId;
        entity.DateAt = DateTime.Now;

        var result = await _context.CreateAndSaveAsync<long, PresentTrackingInfo>(entity, cancellationToken);

        if (result != 0)
            return SuccessResult.Create(true);

        return SuccessResult.Create(false);
    }

    private async Task<SuccessResult<bool>> CreateTracingInfo(CreateTrackingInfoCommand createTrackingInfo,
                                                              CancellationToken cancellationToken)
    {
        var entity = createTrackingInfo.CreateEntity<CreateTrackingInfoCommand, TrackingInfo>(_mapper);

        var result = await _context.CreateAndSaveAsync<long, TrackingInfo>(entity, cancellationToken);

        if (result != 0)
            return SuccessResult.Create(true);

        return SuccessResult.Create(false);
    }
}
