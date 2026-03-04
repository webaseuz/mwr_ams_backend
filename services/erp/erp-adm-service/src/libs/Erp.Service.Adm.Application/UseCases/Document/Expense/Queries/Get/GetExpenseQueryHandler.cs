using Erp.Core;
using Erp.Service.Adm.Models;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

public class GetExpenseQueryHandler :
    IRequestHandler<ExpenseGetQuery, ExpenseDto>
{
    private readonly IMainAuthService _authService;
    public GetExpenseQueryHandler(IMainAuthService authService)
    {
        _authService = authService;
    }
    public async Task<ExpenseDto> Handle(
        ExpenseGetQuery request,
        CancellationToken cancellationToken)
    {
        var userInfo = _authService.User;
        var newDto = new ExpenseDto();
        newDto.BranchId = userInfo.BranchId;
        newDto.DocDate = DateTime.Now;

        newDto.CanCreateForAllBranch = _authService.HasPermission(nameof(PermissionCode.AllViewExpense));

        return await Task.FromResult(newDto);
    }
}
