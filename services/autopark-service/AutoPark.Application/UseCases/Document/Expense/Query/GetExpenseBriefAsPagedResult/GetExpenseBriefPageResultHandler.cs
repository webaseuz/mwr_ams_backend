using AutoPark.Application.Security;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class GetExpenseBriefPageResultHandler :
    IRequestHandler<GetExpenseBriefPageResultQuery, PagedResultWithActionControls<ExpenseBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetExpenseBriefPageResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<ExpenseBriefDto>> Handle(
        GetExpenseBriefPageResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Expense, ExpenseBriefDto>(_context.Expenses);

        query = await query.SortFilter(request, _authService, _context);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.ExpenseCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls: actionControls, cancellationToken);


        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}

public static class ExpenseBriefDtoExtension
{
    public static async Task<IEnumerable<ExpenseBriefDto>> SetActionControls(this IEnumerable<ExpenseBriefDto> query,
                                                                         IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            var hasAccept = permissions.Contains(nameof(PermissionCode.ExpenseAccept));

            ent.CanAccept = StatusIdConst.CanExpenseStatus(ent.StatusId, StatusIdConst.ACCEPTED) &&
                           permissions.Contains(nameof(PermissionCode.ExpenseAccept));

            ent.CanCancel = false;

            /*ent.CanCancel = StatusIdConst.CanExpenseStatus(ent.StatusId, StatusIdConst.CANCELLED) &&
                            permissions.Contains(nameof(PermissionCode.ExpenselCancel));*/

            ent.CanModify = StatusIdConst.CanExpenseStatus(ent.StatusId, StatusIdConst.MODIFIED) &&
                            permissions.Contains(nameof(PermissionCode.ExpenseEdit)) ||
                            StatusIdConst.CanInvoice(ent.StatusId) &&
                            permissions.Contains(nameof(PermissionCode.InvoiceAttach));

            ent.CanDelete = StatusIdConst.CanExpenseStatus(ent.StatusId, StatusIdConst.DELETED) &&
                            permissions.Contains(nameof(PermissionCode.ExpenseDelete));

            ent.CanRevoke = StatusIdConst.CanExpenseStatus(ent.StatusId, StatusIdConst.REVOKED) &&
                            permissions.Contains(nameof(PermissionCode.ExpenseRevoke));

            ent.CanSend = StatusIdConst.CanExpenseStatus(ent.StatusId, StatusIdConst.SEND) &&
                            permissions.Contains(nameof(PermissionCode.ExpenseSend));
        }

        return query;
    }
}