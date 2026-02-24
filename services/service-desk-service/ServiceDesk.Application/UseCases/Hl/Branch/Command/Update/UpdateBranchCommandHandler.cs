using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Branches;

public class UpdateBranchCommandHandler :
    IRequestHandler<UpdateBranchCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public UpdateBranchCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Branches
            .IsSoftActive()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        request.UpdateEntity(entity, _mapper);

        await _context.SaveChangesAsync(cancellationToken);

        return HaveId.Create(request.Id);
    }
}