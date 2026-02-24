using ServiceDesk.Domain;
using Bms.Core.Application;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Permissons;

public static class PermissionSelectList
{
	public static IEnumerable<PermissionGroupSelectListDto> AsSelectList(this IQueryable<Permission> query,
																		CancellationToken cancellationToken)
	{
		return query
				.Include(a => a.Translates)
				.Include(a => a.SubGroup)
				.Include(a => a.SubGroup.Group)
				.IsSoftActive()
				.AsEnumerable()
				.GroupBy(a => a.SubGroup.Group, (groupKey, groupResults) => new PermissionGroupSelectListDto
				{
					Id = groupKey.Id,
					ShortName = groupKey.ShortName,
					FullName = groupKey.FullName,
					SubGroups = groupResults.GroupBy(b => b.SubGroup, (subGroupKey, subGroupResults) => new PermissionSubGroupSelectListDto
					{
						Id = subGroupKey.Id,
						Code = subGroupKey.Code,
						ShortName = subGroupKey.ShortName,
						FullName = subGroupKey.FullName,
						Permissions = subGroupResults.Select(c => new PermissionSelectListDto
						{
							Id = c.Id,
							Code = c.Code,
							ShortName = c.ShortName,
							FullName = c.FullName,
						})
					})
				});
	}
}

