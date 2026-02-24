using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public static class PresentSpareTurnoverSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<DeviceSpareType> query,
                                                                IReadEfCoreContext _context,
                                                                int BranchId,
                                                                CancellationToken cancellationToken)
    {
        var result = await query
            .GroupJoin(
                _context.PresentSpareTurnovers.Where(x => x.BranchId == BranchId && x.IsDeleted == false),
                dst => dst.Id,
                pst => pst.DeviceSpareTypeId,
                (dst, pstGroup) => new { dst, pstGroup }
            )
            .SelectMany(
                x => x.pstGroup.DefaultIfEmpty(),
                (x, pst) => new DeviceSpareTypeSelectListItem<int>
                {
                    Value = x.dst.Id,
                    Text = x.dst.FullName,
                    Quantity = pst != null ? pst.Quantity : 0,
                    OrderCode = x.dst.OrderCode,
                    Nomenclature = x.dst.Nomenclature
                }
            )
            .ToListAsync();

        return [.. result];
    }
}
