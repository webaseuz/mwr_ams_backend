using AutoMapper;
using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

public class GetExpenseByIdQueryHandler :
    IRequestHandler<ExpenseGetByIdQuery, ExpenseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMainAuthService _authService;
    private readonly ICultureHelper _cultureHelper;
    private readonly ILocalizationBuilder _localizationBuilder;

    public GetExpenseByIdQueryHandler(
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

    public async Task<ExpenseDto> Handle(
        ExpenseGetByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.Expenses
            .Where(b => b.Id == request.Id);

        var dto = await query.MapTo<ExpenseDto>(_mapper, _cultureHelper)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto is null)
            throw new WbClientException()
               .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
               .WithErrors(new WbFailure
               {
                   Key = "DOCUMENT_NOT_FOUND",
                   ErrorMessage = _localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
               });

        dto.CanCreateForAllBranch = _authService.HasPermission(nameof(AutoparkPermissionCode.AllViewExpense));

        dto.CanInvoice = _authService.HasPermission(nameof(AutoparkPermissionCode.InvoiceAttach)) && StatusIdConst.CanInvoice(dto.StatusId);

        return dto;
    }
}
