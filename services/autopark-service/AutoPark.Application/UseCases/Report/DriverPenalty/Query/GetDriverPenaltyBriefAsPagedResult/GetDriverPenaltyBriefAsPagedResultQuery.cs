using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.DriverPenalties;

public class GetDriverPenaltyBriefAsPagedResultQuery
    : SortFilterPageOptions,
    IRequest<PagedResult<DriverPenaltyBriefDto>>
{
    public int? RegionId { get; set; }
    public int? BranchId { get; set; }
    public long? DriverId { get; set; }
    public long? TransportId { get; set; }
    public string RegistrationNumber { get; set; }
    public DateTime? ExpireFromDate { get; set; }
    public DateTime? ExpireToDate { get; set; }

    public void Init()
    {
        var now = DateTime.Now;

        if (!ExpireFromDate.HasValue)
            ExpireFromDate = new DateTime(now.Year,
                                          now.Month,
                                          1);

        if (!ExpireToDate.HasValue)
            ExpireToDate = now;

        if (ExpireFromDate > ExpireToDate)
        {
            DateTime? tempDate = ExpireFromDate;
            ExpireFromDate = ExpireToDate;
            ExpireToDate = tempDate;
        }
    }
}