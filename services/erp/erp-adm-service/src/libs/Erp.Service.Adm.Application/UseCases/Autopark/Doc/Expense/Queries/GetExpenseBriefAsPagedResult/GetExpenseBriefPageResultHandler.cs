using AutoMapper;
using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

public class GetExpenseBriefPageResultHandler :
    IRequestHandler<ExpenseGetBriefPageResultQuery, WbPagedResult<ExpenseBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMainAuthService _authService;
    private readonly ICultureHelper _cultureHelper;
    private readonly ILocalizationBuilder _localizationBuilder;

    public GetExpenseBriefPageResultHandler(
        IApplicationDbContext context,
        IMapper mapper,
        IMainAuthService authService,
        ICultureHelper cultureHelper,
        ILocalizationBuilder localizationBuilder)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
        _cultureHelper = cultureHelper;
        _localizationBuilder = localizationBuilder;
    }

    public async Task<WbPagedResult<ExpenseBriefDto>> Handle(
        ExpenseGetBriefPageResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.Expenses.AsQueryable().MapTo<ExpenseBriefDto>(_mapper, _cultureHelper);

        query = await query.SortFilter(request, _authService, _context);

        var result = await query.AsPagedResultAsync(request);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}

public static class ExpenseBriefDtoExtension
{
    public static async Task<IEnumerable<ExpenseBriefDto>> SetActionControls(this IEnumerable<ExpenseBriefDto> query,
                                                                         IMainAuthService authService)
    {
        foreach (var ent in query)
        {
            var hasAccept = authService.HasPermission(nameof(AutoparkPermissionCode.ExpenseAccept));

            ent.CanAccept = StatusIdConst.CanExpenseStatus(ent.StatusId, StatusIdConst.ACCEPTED) &&
                           authService.HasPermission(nameof(AutoparkPermissionCode.ExpenseAccept));

            ent.CanCancel = false;

            /*ent.CanCancel = StatusIdConst.CanExpenseStatus(ent.StatusId, StatusIdConst.CANCELLED) &&
                            permissions.Contains(nameof(AutoparkPermissionCode.ExpenselCancel));*/

            ent.CanModify = StatusIdConst.CanExpenseStatus(ent.StatusId, StatusIdConst.MODIFIED) &&
                            authService.HasPermission(nameof(AutoparkPermissionCode.ExpenseEdit)) ||
                            StatusIdConst.CanInvoice(ent.StatusId) &&
                            authService.HasPermission(nameof(AutoparkPermissionCode.InvoiceAttach));

            ent.CanDelete = StatusIdConst.CanExpenseStatus(ent.StatusId, StatusIdConst.DELETED) &&
                            authService.HasPermission(nameof(AutoparkPermissionCode.ExpenseDelete));

            ent.CanRevoke = StatusIdConst.CanExpenseStatus(ent.StatusId, StatusIdConst.REVOKED) &&
                            authService.HasPermission(nameof(AutoparkPermissionCode.ExpenseRevoke));

            ent.CanSend = StatusIdConst.CanExpenseStatus(ent.StatusId, StatusIdConst.SEND) &&
                            authService.HasPermission(nameof(AutoparkPermissionCode.ExpenseSend));
        }

        return await Task.FromResult(query);
    }
}
