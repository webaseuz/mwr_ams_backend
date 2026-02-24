using AutoPark.Application.Security;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Expenses;

public class GetExpenseByIdQueryHandler :
    IRequestHandler<GetExpenseByIdQuery, ExpenseDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetExpenseByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<ExpenseDto> Handle(
        GetExpenseByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.Expenses
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<Expense, ExpenseDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        var permissions = await _authService.GetPermissionsAsync();

        dto.CanCreateForAllBranch = permissions.Contains(nameof(PermissionCode.AllViewExpense));

        dto.CanInvoice = permissions.Contains(nameof(PermissionCode.InvoiceAttach)) && StatusIdConst.CanInvoice(dto.StatusId);

        return dto;
    }
}
