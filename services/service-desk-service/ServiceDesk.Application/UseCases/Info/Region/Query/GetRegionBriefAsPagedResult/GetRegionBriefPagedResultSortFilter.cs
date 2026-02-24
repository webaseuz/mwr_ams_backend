using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace ServiceDesk.Application.UseCases.Regions;

public static class GetRegionBriefPagedResultSortFilter
{
	public static IQueryable<RegionBriefDto> SortFilter(
		this IQueryable<RegionBriefDto> query,
		GetRegionBriefPagedResultQuery request)
	{
		if (request.HasSearch())
		{
			string target = request.Search.ToLower();

			query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
									 a.FullName.ToLower().Contains(target) ||
									 a.OrderCode.Contains(target));
		}

		if (request.HasSort() && request.IsValidSortBy<RegionBriefDto>())
			query = query.OrderBy($"{request.SortBy} {request.OrderType}");
		else
			query = query.OrderByDescending(a => a.Id);

		return query;
	}
}
