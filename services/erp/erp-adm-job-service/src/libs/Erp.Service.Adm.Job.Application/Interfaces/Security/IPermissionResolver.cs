using WEBASE;

namespace Erp.Service.Adm.Job.Application;

public interface IPermissionResolver
{
    Task InitIfNeededAsync();

    Task ResolvePermissionsAsync<TPermissionCodeEnum, TPermission, TPermissionTranslate, TPermissionSubGroup, TPermissionSubGroupTranslate>()
        where TPermissionCodeEnum : struct
        where TPermission : class, IWbPermissionEntity<int, TPermissionTranslate, TPermissionSubGroup, TPermissionSubGroupTranslate>, new()
        where TPermissionTranslate : class, IWbTranslateEntity<int>, new()
        where TPermissionSubGroup : class, IWbPermissionSubGroupEntity<int, TPermissionSubGroupTranslate>, new()
        where TPermissionSubGroupTranslate : class, IWbTranslateEntity<int>, new();
}
