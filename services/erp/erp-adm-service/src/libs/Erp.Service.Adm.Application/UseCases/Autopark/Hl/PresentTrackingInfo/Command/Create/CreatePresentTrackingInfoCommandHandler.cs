using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CreatePresentTrackingInfoCommandHandler(
    IApplicationDbContext context,
    IMainAuthService authService) : IRequestHandler<PresentTrackingInfoCreateCommand, bool>
{
    public async Task<bool> Handle(PresentTrackingInfoCreateCommand request, CancellationToken cancellationToken)
    {
        var personId = (long)authService.User.PersonId;
        var dateAt = DateTime.Now;

        var presentEntity = new PresentTrackingInfo
        {
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            PersonId = personId,
            DateAt = dateAt
        };

        await context.PresentTrackingInfos.AddAsync(presentEntity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var trackingEntity = new TrackingInfo
        {
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            PersonId = personId,
            DateAt = dateAt
        };

        await context.TrackingInfos.AddAsync(trackingEntity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
