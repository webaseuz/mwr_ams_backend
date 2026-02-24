using Bms.WEBASE.EF;

namespace AutoPark.Application;

public interface IWriteEfCoreContext :
    IBaseEfCoreDbContext,
    IDbContext// EfCore Db Context for WRITE operations
{
    //Bu yerga hich narsa yozish mumkin emas hammasi IBaseEfCoreDbContext da yoziladi umumiy Set lar
}