using AutoPark.Application.UseCases.ExpenseLimits;
using AutoPark.Application.UseCases.Report;

namespace AutoPark.Application;

public interface IReadEfCoreContext :
    IBaseEfCoreDbContext // EfCore Db Context for READ operations
{
    public IQueryable<TotalExpenseReportListDto> GetTotalExpenseReport(int? branchId, int? transportId, int? driverId, DateTime? fromDate, DateTime? toDate);
    public IQueryable<ExpenseReportList> GetExpenseReport(int? branchId, int? transportId, int? driverId, DateTime? fromDate, DateTime? toDate);
    public IQueryable<TotalExpenseLimitReportListDto> GetTotalExpenseLimitReport(int? branchId, int? transportId, int? driverId, DateTime? fromDate, DateTime? toDate);
    public IQueryable<ExpenseLimitReportList> GetExpenseLimitReport(int? branchId, int? transportId, int? driverId, DateTime? fromDate, DateTime? toDate);

    //Bu yerga hich narsa yozish mumkin emas hammasi IBaseEfCoreDbContext da yoziladi umumiy Set lar
    // !!! There must not be written SaveChangesAsync because this context is not responsible for modification in Source.it is responsible for only read operations
}