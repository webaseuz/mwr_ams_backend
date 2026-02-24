using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Departments;

public class DepartmentSelectListQueryHandler
    : IRequestHandler<DepartmentSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public DepartmentSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(DepartmentSelectListQuery request,
                                               CancellationToken cancellationToken)
        => await _context.Departments
                .IsSoftActive()
                .AsSelectList(request, cancellationToken);
}
