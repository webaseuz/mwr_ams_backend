

using Microsoft.AspNetCore.Mvc;
using WEBASE.LogSdk.Core.AuthorizeFilters;
using WEBASE.LogSdk.Core.Enums;

namespace WEBASE.LogSdk.Core.Attributes;

/// <summary>
/// LogSdk ichidagi ruxsatlarni tekshiruvchi atribut.
/// Controller yoki Action ustida ishlatiladi.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
internal class LogSdkAuthorizeAttribute : TypeFilterAttribute

{
    /// <summary>
    /// Default konstruktor – faqat AppErrorView ruxsati kerak bo‘lgan joyda ishlatiladi.
    /// </summary>
    public LogSdkAuthorizeAttribute()
        : base(typeof(LogSdkAuthorizeFilter))
    {
        Arguments = new[]
        {
            new string[]
            {
                LogSdkPermissionCode.AppErrorView.ToString(),
            }
        };
    }

    /// <summary>
    /// Maxsus ruxsat kodlarini parametr sifatida qabul qiladi.
    /// </summary>
    /// <param name="permissionCode">Talab qilinadigan ruxsatlar ro'yxati</param>
    public LogSdkAuthorizeAttribute(params LogSdkPermissionCode[] permissionCode)
        : base(typeof(LogSdkAuthorizeFilter))
    {
        Arguments = new[]
        {
            permissionCode.Select(x => x.ToString()).ToArray()
        };
    }
}
