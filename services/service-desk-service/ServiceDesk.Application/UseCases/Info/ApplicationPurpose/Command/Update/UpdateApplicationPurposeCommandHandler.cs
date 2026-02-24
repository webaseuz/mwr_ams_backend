using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.UseCases.DeviceModels;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

public class UpdateApplicationPurposeCommandHandler :
    IRequestHandler<UpdateApplicationPurposeCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public UpdateApplicationPurposeCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(
        UpdateApplicationPurposeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.ApplicationPurposes
            .Include(b => b.Translates)
            .IsSoftActive()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        request.UpdateEntity(entity, _mapper);

        request.Translates.ApplyChangesByUniqueFKTo(entity.Translates, _mapper);

        await _context.SaveChangesAsync(cancellationToken);

        return HaveId.Create(request.Id);
    }
}
