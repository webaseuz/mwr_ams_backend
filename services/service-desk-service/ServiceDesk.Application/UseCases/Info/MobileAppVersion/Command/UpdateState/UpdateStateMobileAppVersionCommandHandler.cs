using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class UpdateStateMobileAppVersionCommandHandler :
    IRequestHandler<UpdateStateMobileAppVersionCommand, IHaveId<Guid>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    public UpdateStateMobileAppVersionCommandHandler(
        IWriteEfCoreContext context, IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<Guid>> Handle(
        UpdateStateMobileAppVersionCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.MobileAppVersions
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        if (request.StateId == StateIdConst.ACTIVE)
            entity.MarkAsActive();
        else if (request.StateId == StateIdConst.PASSIVE)
            entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return HaveId.Create(request.Id);
    }
}
