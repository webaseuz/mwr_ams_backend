using AutoPark.Application.Security;
using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class GetExpenseQueryHandler :
    IRequestHandler<GetExpenseQuery, ExpenseDto>
{
    private readonly IAsyncAppAuthService _authService;
    public GetExpenseQueryHandler(IAsyncAppAuthService authService)
    {
        _authService = authService;
    }
    public async Task<ExpenseDto> Handle(
        GetExpenseQuery request,
        CancellationToken cancellationToken)
    {
        var userInfo = await _authService.GetUserAsync();
        var newDto = new ExpenseDto();
        newDto.BranchId = userInfo.BranchId;
        newDto.DocDate = DateTime.Now;

        var permissions = await _authService.GetPermissionsAsync();

        newDto.CanCreateForAllBranch = permissions.Contains(nameof(PermissionCode.AllViewExpense));

        return newDto;
    }
}
