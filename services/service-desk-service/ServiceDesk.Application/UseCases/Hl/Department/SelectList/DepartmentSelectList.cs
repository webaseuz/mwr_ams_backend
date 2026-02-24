using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Departments
{
    public static class DepartmentSelectList
    {
        public static async Task<SelectList<int>> AsSelectList(this IQueryable<Department> query,
                                                               DepartmentSelectListQuery request,
                                                               CancellationToken cancellationToken)
        {
            if (request.BranchId.HasValue)
                query = query.Where(a => a.BranchId == request.BranchId);

            var result = await query.Select(a =>
                new SelectListItem<int>
                {
                    Value = a.Id,
                    Text = a.ShortName,
                })
                .ToListAsync(cancellationToken);

            return [.. result];
        }
    }
}
