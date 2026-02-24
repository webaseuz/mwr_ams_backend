using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEBASE.EF;
using WEBASE.LogSdk.DAL.EfClasses;

namespace WEBASE.LogSdk.DAL;

public abstract class LogSdkContext : BaseDbContext
{
    protected LogSdkContext(DbContextOptions options)
        : base(options)
    {
        Config.AutoSetProperties.DateOfCreated.PropertyName = nameof(ErrorScope.CreatedAt);
        Config.AutoSetProperties.DateOfModified.PropertyName = nameof(ErrorScope.ModifiedAt);
    }

    public virtual DbSet<AppError> AppErrors { get; set; } = default!;
    public virtual DbSet<AppErrorArchive> AppErrorArchive { get; set; } = default!;

    public virtual DbSet<ErrorScope> ErrorScopes { get; set; } = default!;
    public virtual DbSet<ErrorScopeArchive> ErrorScopeArchieves { get; set; } = default!;

    protected abstract void ConfigureAppError<T>(EntityTypeBuilder<T> builder, string tableName)
        where T : AppErrorBase;

    protected abstract void ConfigureErrorScope<T>(EntityTypeBuilder<T> builder, string tableName)
        where T : ErrorScopeBase;
}
