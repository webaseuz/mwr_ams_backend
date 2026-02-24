using AutoPark.Domain;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Departments
{
    public static class DepartmentSelectList
    {
        public static async Task<SelectList<int>> AsSelectList(this IQueryable<Department> query,
                                                               DepartmentSelectListQuery request,
                                                               CancellationToken cancellationToken)
        {
            if (request.BranchId.HasValue)
                query = query.Where(a => a.BranchId == request.BranchId);

            var result = await query
                .IsSoftActive()
                .Select(a =>
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
