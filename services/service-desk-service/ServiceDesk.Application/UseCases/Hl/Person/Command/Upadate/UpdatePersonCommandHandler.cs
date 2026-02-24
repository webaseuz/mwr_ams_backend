using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Persons;

public class UpdatePersonCommandHandler :
    IRequestHandler<UpdatePersonCommand, IHaveId<long>>

{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public UpdatePersonCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<long>> Handle(
        UpdatePersonCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.People
           .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        request.UpdateEntity(entity, _mapper);

        await _context.SaveChangesAsync(cancellationToken);

        return HaveId.Create(request.Id);
    }
}