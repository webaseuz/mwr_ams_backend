using Bms.Core.Application;
using System.Linq.Dynamic.Core;


namespace AutoPark.Application.UseCases.Persons;

public static class GetPersonBriefPagedResultsSortFilter
{
    public static IQueryable<PersonPriefDto> SortFilter(
        this IQueryable<PersonPriefDto> query,
        GetPersonBriefPagedResultQuery request)
    {
        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.FirstName.ToLower().Contains(target) ||
                                     a.LastName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.MiddleName.ToLower().Contains(target) ||
                                     a.DocumentSeria.ToLower().Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<PersonPriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}
