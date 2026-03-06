using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CreateTrackingInfoCommandHandler(
    IApplicationDbContext context) : IRequestHandler<TrackingInfoCreateCommand, bool>
{
    public async Task<bool> Handle(TrackingInfoCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new TrackingInfo
        {
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            PersonId = request.PersonId,
            DateAt = request.DateAt
        };

        await context.TrackingInfos.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
