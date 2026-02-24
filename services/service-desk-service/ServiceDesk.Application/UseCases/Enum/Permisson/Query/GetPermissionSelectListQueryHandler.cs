using Bms.WEBASE.EF;
using MediatR;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Entities.Sys;

namespace ServiceDesk.Application.UseCases.Permissons;

public class GetPermissionSelectListQueryHandler :
    IRequestHandler<GetPermissionSelectListQuery, IEnumerable<PermissionGroupSelectListDto>>
{
    private readonly IWriteEfCoreContext _writeContext;
    private static bool PERMISSION_CODE_INITIALIZED = false;

    public GetPermissionSelectListQueryHandler(IWriteEfCoreContext writeContext)
    {
        _writeContext = writeContext;
    }

    public  Task<IEnumerable<PermissionGroupSelectListDto>> Handle(
        GetPermissionSelectListQuery request,
        CancellationToken cancellationToken)
    {
        if (!PERMISSION_CODE_INITIALIZED)
        {
            _writeContext.ResolveModules<PermissionCode, Permission, PermissionTranslate, PermissionSubGroup, PermissionSubGroupTranslate>();
            PERMISSION_CODE_INITIALIZED = true;
        }

        return Task.FromResult(_writeContext.Permissions
        .AsSelectList(cancellationToken));
    }
}
