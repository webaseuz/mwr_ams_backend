using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEBASE.LogSdk.DAL.EfClasses;

namespace WEBASE.LogSdk.DAL;

public class PgSqlContext : LogSdkContext
{
    public PgSqlContext(DbContextOptions options)
        : base(options)
    {
    }
    /// <summary>
    /// Override this method to configure the model and set up the database schema.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureErrorScope(modelBuilder.Entity<ErrorScope>(), "sys_error_scope");
        ConfigureErrorScope(modelBuilder.Entity<ErrorScopeArchive>(), "sys_error_scope_archive");
        ConfigureAppError(modelBuilder.Entity<AppError>(), "sys_app_error");
        ConfigureAppError(modelBuilder.Entity<AppErrorArchive>(), "sys_app_error_archive");

        Constraints(modelBuilder);
    }

    /// <summary>
    /// Override this method to configure the model and set up the database schema.
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void Constraints(ModelBuilder modelBuilder)
    {
        // Configure the unique index for ErrorScope
        modelBuilder.Entity<ErrorScope>()
                    .HasIndex(ent => new { ent.HostName, ent.Type, ent.NormalizedRequestPath, ent.ScopeKey, ent.Code })
                    .IsUnique()
                    .HasDatabaseName("ux_log__sys_error_scope__structure_unique");

        // Configure the foreign key relationship between AppError and ErrorScope
        modelBuilder.Entity<AppError>()
            .HasOne(ent => ent.ErrorScope)
            .WithMany()
            .HasForeignKey(ent => ent.ErrorScopeId)
            .HasConstraintName("fk_log__sys_app_error__scope")
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the foreign key relationship between AppErrorArchive and ErrorScopeArchive
        modelBuilder.Entity<AppErrorArchive>()
            .HasOne(ent => ent.ErrorScopeArchive)
            .WithMany()
            .HasForeignKey(ent => ent.ErrorScopeId)
            .HasConstraintName("fk_log__sys_app_error_archive__scope")
            .OnDelete(DeleteBehavior.Cascade);
    }

    /// <summary>
    /// Override this method to configure the model and set up the database schema.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <param name="tableName"></param>
    protected override void ConfigureAppError<T>(EntityTypeBuilder<T> builder, string tableName)
    {
        // Configure the table name and schema
        if (Database.IsNpgsql())
        {
            builder.ToTable(tableName, "log");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("BIGINT")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.RequestTraceId).HasColumnName("request_trace_id");
            builder.Property(e => e.UserId).HasColumnName("user_id");
            builder.Property(e => e.UserName).HasColumnName("user_name");
            builder.Property(e => e.HostName).HasColumnName("host_name");
            builder.Property(e => e.RequestPath).HasColumnName("request_path");
            builder.Property(e => e.RequestParams).HasColumnName("request_params");
            builder.Property(e => e.RequestBody).HasColumnName("request_body");
            builder.Property(e => e.StatusCode).HasColumnName("status_code");
            builder.Property(e => e.Type).HasColumnName("type");
            builder.Property(e => e.Detail).HasColumnName("detail");
            builder.Property(e => e.Title).HasColumnName("title");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp without time zone");
            builder.Property(e => e.IpAddress).HasColumnName("ip_address");
            builder.Property(e => e.UserAgent).HasColumnName("user_agent");
            builder.Property(e => e.UserAgentOS).HasColumnName("user_agent_os");
            builder.Property(e => e.UserAgentDevice).HasColumnName("user_agent_device");
            builder.Property(e => e.UserAgentUA).HasColumnName("user_agent_ua");

            builder.Property(e => e.NormalizedRequestPath).HasColumnName("normalized_request_path");
            builder.Property(e => e.Code).HasColumnName("code");
            builder.Property(e => e.ErrorScopeId).HasColumnName("error_scope_id");
        }
    }

    /// <summary>
    /// Override this method to configure the model and set up the database schema.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <param name="tableName"></param>
    protected override void ConfigureErrorScope<T>(EntityTypeBuilder<T> builder, string tableName)
    {
        if (Database.IsNpgsql())
        {
            builder.ToTable(tableName, "log");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("BIGINT")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.HostName).HasColumnName("host_name");
            builder.Property(e => e.NormalizedRequestPath).HasColumnName("normalized_request_path");
            builder.Property(e => e.Type).HasColumnName("type");
            builder.Property(e => e.Title).HasColumnName("title");
            builder.Property(e => e.Code).HasColumnName("code");
            builder.Property(e => e.IsFixed).HasColumnName("is_fixed");
            builder.Property(e => e.ScopeKey).HasColumnName("scope_key");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp without time zone");
            builder.Property(e => e.ModifiedAt).HasColumnName("modified_at").HasColumnType("timestamp without time zone");
        }
    }

}

/// <summary>
/// Design-time DbContext factory for creating instances of PgSqlContext.
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PgSqlContext>
{
    /// <summary>
    /// Creates a new instance of PgSqlContext with the specified options.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public PgSqlContext CreateDbContext(string[] args)
    {
        // Set the legacy timestamp behavior switch for Npgsql
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        // Create a new DbContextOptionsBuilder with PostgreSQL options
        var builder = new DbContextOptionsBuilder<PgSqlContext>();
        builder.UseNpgsql("User ID=postgres;Password=AAaa@@11;Host=localhost;Port=5432;Database=LogSdk;Include Error Detail=true;Pooling=true;");
        return new PgSqlContext(builder.Options);
    }
}
