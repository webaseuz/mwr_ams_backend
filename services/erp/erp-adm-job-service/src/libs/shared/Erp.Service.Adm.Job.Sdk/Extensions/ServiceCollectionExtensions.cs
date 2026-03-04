using Erp.Core.Sdk;
using Microsoft.Extensions.DependencyInjection;

namespace Erp.Service.Adm.Job.Sdk;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureAdmJobSdk(this IServiceCollection services, SdkConfig config)
    {
        services.AddSdkHandlers(config);

        services.RegisterApiClient<IAccountApi>(config);
        services.RegisterApiClient<IBankApi>(config);
        services.RegisterApiClient<IEduDirectionApi>(config);
        services.RegisterApiClient<ISpecialtyApi>(config);
        services.RegisterApiClient<IKinshipDegree>(config);
        services.RegisterApiClient<INationalityApi>(config);
        services.RegisterApiClient<IDistrictApi>(config);
        services.RegisterApiClient<IRegionApi>(config);
        services.RegisterApiClient<ICountryApi>(config);
        services.RegisterApiClient<IOrganizationalFormApi>(config);
        services.RegisterApiClient<IEduYearApi>(config);
        services.RegisterApiClient<IInstitutionTypeApi>(config);
        services.RegisterApiClient<IMfyApi>(config);
        services.RegisterApiClient<IOkedApi>(config);
        services.RegisterApiClient<IOrganizationApi>(config);
        services.RegisterApiClient<IOrganizationTypeApi>(config);
        services.RegisterApiClient<IUserApi>(config);
        services.RegisterApiClient<IRoleApi>(config);
        services.RegisterApiClient<IPersonApi>(config);
        services.RegisterApiClient<ISystemApi>(config);
        services.RegisterApiClient<IManualApi>(config);
        services.RegisterApiClient<IReportApi>(config);
        services.RegisterApiClient<IDocumentStatusApi>(config);
        services.RegisterApiClient<IItemOfExpenseApi>(config);
        services.RegisterApiClient<ICalculationKindApi>(config);
        services.RegisterApiClient<IFixedMinimumValueApi>(config);
        services.RegisterApiClient<INumberApi>(config);
        services.RegisterApiClient<ITableApi>(config);
        services.RegisterApiClient<ICitizenshipApi>(config);
        services.RegisterApiClient<IFileConfigApi>(config);
        services.RegisterApiClient<IAppApi>(config);

        return services;
    }
}
