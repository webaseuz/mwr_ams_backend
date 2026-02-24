using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TrackingInfos;

public class CreateTrackingInfoCommandHandler :
    IRequestHandler<CreateTrackingInfoCommand, SuccessResult<bool>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateTrackingInfoCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        CreateTrackingInfoCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateTrackingInfoCommand, TrackingInfo>(_mapper);

        var result = await _context.CreateAndSaveAsync<long, TrackingInfo>(entity, cancellationToken);

        if (result != 0)
            return SuccessResult.Create(true);
        return SuccessResult.Create(false);
    }
}
