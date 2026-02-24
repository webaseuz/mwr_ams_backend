using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace ServiceDesk.Application.UseCases.Organizations;

public static class GetOrganizationBriefPagedResultSortFilter
{
	public static IQueryable<OrganizationBriefDto> SortFilter(
		this IQueryable<OrganizationBriefDto> query,
		GetOrganizationBriefPagedResultQuery request)
	{
		if (request.HasSearch())
		{
			string target = request.Search.ToLower();

			query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
									 a.FullName.ToLower().Contains(target) ||
									 a.OrderCode.Contains(target) ||
									 a.Inn.Contains(target));
		}

		if (request.HasSort() && request.IsValidSortBy<OrganizationBriefDto>())
			query = query.OrderBy($"{request.SortBy} {request.OrderType}");
		else
			query = query.OrderByDescending(a => a.Id);

		return query;
	}
}
