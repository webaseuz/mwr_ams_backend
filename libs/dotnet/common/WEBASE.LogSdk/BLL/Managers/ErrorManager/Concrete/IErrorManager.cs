using StatusGeneric;
using WEBASE.LogSdk.DAL.EfClasses;

namespace WEBASE.LogSdk.BLL.Managers;

public interface IErrorManager : IStatusGeneric
{
    public Task ErrorOccuredAsync(AppError appError);
}
