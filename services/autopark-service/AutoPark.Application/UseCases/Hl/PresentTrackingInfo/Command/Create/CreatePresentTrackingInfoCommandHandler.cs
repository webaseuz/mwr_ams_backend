using AutoPark.Application.Security;
using AutoPark.Application.UseCases.TrackingInfos;
using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class CreatePresentTrackingInfoCommandHandler :
    IRequestHandler<CreatePresentTrackingInfoCommand, SuccessResult<bool>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;
    private readonly IAsyncAppAuthService _authService;

    public CreatePresentTrackingInfoCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context,
        IAsyncAppAuthService authService)
    {
        _mapper = mapper;
        _context = context;
        _authService = authService;
    }

    public async Task<SuccessResult<bool>> Handle(
        CreatePresentTrackingInfoCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreatePresentTrackingInfoCommand, PresentTrackingInfo>(_mapper);

        entity.PersonId = (await _authService.GetUserAsync()).PersonId;
        entity.DateAt = DateTime.Now;

        var result = await _context.CreateAndSaveAsync<long, PresentTrackingInfo>(entity, cancellationToken);

        if (result != 0)
        {
            var resultInfo = await CreateTracingInfo(new CreateTrackingInfoCommand
            {
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                PersonId = entity.PersonId,
                DateAt = entity.DateAt
            }, cancellationToken);

            if (resultInfo.Success)
            {
                await _context.SaveChangesAsync(cancellationToken);
                return SuccessResult.Create(true);
            }
        }

        return SuccessResult.Create(false);
    }


    private async Task<SuccessResult<bool>> CreateTracingInfo(CreateTrackingInfoCommand createTrackingInfo, CancellationToken cancellationToken)
    {
        var entity = createTrackingInfo.CreateEntity<CreateTrackingInfoCommand, TrackingInfo>(_mapper);

        var result = await _context.CreateAndSaveAsync<long, TrackingInfo>(entity, cancellationToken);

        if (result != 0)
            return SuccessResult.Create(true);

        return SuccessResult.Create(false);
    }
}
