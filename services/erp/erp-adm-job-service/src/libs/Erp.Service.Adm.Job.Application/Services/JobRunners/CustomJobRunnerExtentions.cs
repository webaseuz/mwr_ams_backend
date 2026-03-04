using Microsoft.Extensions.DependencyInjection;


namespace Erp.Service.Adm.Job.Application.Services.JobRunners;


public static class CustomJobRunnerExtentions
{
    public static void AddCustomJobRunner(this IServiceCollection services)
    {
        services.AddScoped<ICustomJobRunnerFactory, CustomJobRunnerFactory>();
        services.AddScoped<ISyncUserWithEmployeeActionExecutor, SyncUserWithEmployeeJobActionExecutor>();
        services.AddScoped<ISyncUserWithEmployeeActionInputDataSource, SyncUserWithEmployeeActionInputDataSource>();
        services.AddScoped<ISyncUserWithEmployeeJobRunner, SyncUserWithEmployeeJobRunner>();
        
        services.AddScoped<IUpdatePersonDataJobRunner, UpdatePersonDataJobRunner>();
        services.AddScoped<IUpdatePersonDataActionInputDataSource, UpdatePersonDataActionInputDataSource>();
        services.AddScoped<IUpdatePersonDataActionExecutor, UpdatePersonDataActionExecutor>();
    }
}
