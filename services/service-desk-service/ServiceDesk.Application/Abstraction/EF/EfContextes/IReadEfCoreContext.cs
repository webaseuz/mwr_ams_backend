using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.UseCases.Report.SpareTurnover;

namespace ServiceDesk.Application;

public interface IReadEfCoreContext :
    IBaseEfCoreDbContext // EfCore Db Context for READ operations
{
    DbSet<SpareTurnoverReportJson> Results { get; set; }
    [DbFunction("get_spare_turnover_report_json2")]
    public IQueryable<SpareTurnoverReportJson> GetSpareTurnoverReport(
                                         int branchId,
                                         int deviceTypeId,
                                         int pageSize,
                                         int pageIndex,
                                         string search,
                                         string sortBy,
                                         string orderBy);

    //Bu yerga hich narsa yozish mumkin emas hammasi IBaseEfCoreDbContext da yoziladi umumiy Set lar
    // !!! There must not be written SaveChangesAsync because this context is not responsible for modification in Source.it is responsible for only read operations
}
