using Bms.Core.Application;
using Bms.Core.Application.Models;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace Bms.WEBASE.Extensions;

public static class PagedResultQueryExtensions
{
    public static PagedResult<TRow> AsPagedResult<TRow>(this IQueryable<TRow> query, IPageOptions options)
    {
        return new PagedResult<TRow>(options.Page, options.PageSize, query.Count(), query.Skip(options.PageSize * (options.Page - 1)).Take(options.PageSize).AsEnumerable());
    }

    public static PagedResult<TRow> AsPagedResult<TRow>(this IQueryable<TRow> query, IPageOptions options, Action<TRow, long> rowNumberSetter)
    {
        return new PagedResult<TRow>(options.Page, options.PageSize, query.Count(), query.Skip(options.PageSize * (options.Page - 1)).Take(options.PageSize).AsEnumerable()
            .Select(delegate (TRow a, int idx)
            {
                rowNumberSetter(a, idx + (options.Page - 1) * options.PageSize + 1);
                return a;
            }));
    }

    public static async Task<PagedResult<TRow>> AsPagedResultAsync<TRow>(
    this IQueryable<TRow> query,
    IPageOptions options,
    CancellationToken cancellationToken = default)
    {
        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip(options.PageSize * (options.Page - 1))
            .Take(options.PageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<TRow>(options.Page, options.PageSize, totalCount, items);
    }

    public static async Task<PagedResultWithActionControls<TRow>> AsPagedResultWithActionControlAsync<TRow>(
    this IQueryable<TRow> query,
    IPageOptions options,
    PagedResultActionControl actionControls = null,
    CancellationToken cancellationToken = default)
    {
        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip(options.PageSize * (options.Page - 1))
            .Take(options.PageSize)
            .ToListAsync(cancellationToken);

        return new PagedResultWithActionControls<TRow>(options.Page,
                                                       options.PageSize,
                                                       totalCount,
                                                       actionControls,
                                                       items);
    }

    public static async Task<PagedResult<TRow>> AsPagedResultAsync<TRow>(
    this IQueryable<TRow> query,
    IPageOptions options,
    Action<TRow, long> rowNumberSetter,
    CancellationToken cancellationToken = default)
    {
        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip(options.PageSize * (options.Page - 1))
            .Take(options.PageSize)
            .ToListAsync(cancellationToken);

        long startIndex = (options.Page - 1) * options.PageSize + 1;

        foreach (var (item, index) in items.Select((value, idx) => (value, idx)))
            rowNumberSetter(item, startIndex + index);

        return new PagedResult<TRow>(options.Page, options.PageSize, totalCount, items);
    }

}
