using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Branches;

public class CreateBranchCommandHandler :
    IRequestHandler<CreateBranchCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;
    private readonly IAsyncAppAuthService _authService;

    public CreateBranchCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context,
        IAsyncAppAuthService authService)
    {
        _mapper = mapper;
        _context = context;
        _authService = authService;
    }

    public async Task<IHaveId<int>> Handle(
        CreateBranchCommand request,
        CancellationToken cancellationToken)
    {
        if (request.OrganizationId is null)
        {
            var organization = await _authService.GetOrganizationAsync();

            if (organization is not null)
                request.OrganizationId = organization.Id;

        }

        var entity = request.CreateEntity<CreateBranchCommand, Branch>(_mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, Branch>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}