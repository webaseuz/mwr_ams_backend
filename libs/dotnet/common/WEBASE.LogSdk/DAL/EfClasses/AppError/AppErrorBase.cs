using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WEBASE.Models;

namespace WEBASE.LogSdk.DAL.EfClasses;

public abstract class AppErrorBase : IHaveIdProp<long>, IEntity<long>
{
    [Key]
    public long Id { get; set; }

    #region SERVER
    [MaxLength(100)]
    [Required]
    public string HostName { get; set; } = null!;
    #endregion

    #region USER
    [MaxLength(50)]
    public string UserId { get; set; }
    [MaxLength(100)]
    public string UserName { get; set; }
    #endregion

    #region REQUEST
    [MaxLength(100)]
    public string RequestTraceId { get; set; }
    [MaxLength(512)]
    [Required]
    public string RequestPath { get; set; } = null!;
    [MaxLength(512)]
    public string RequestParams { get; set; }
    public string RequestBody { get; set; }
    #endregion

    #region ERROR
    [Required]
    public int StatusCode { get; set; }
    [MaxLength(250)]
    public string Type { get; set; }
    public string Detail { get; set; }
    [MaxLength(2000)]
    public string Title { get; set; }
    #endregion

    #region AUDITABLE
    [JsonConverter(typeof(DateTimeConverter))]
    [Required]
    public DateTime CreatedAt { get; set; }
    #endregion

    #region SECINFO
    [StringLength(200)]
    public string IpAddress { get; set; }
    [StringLength(2000)]
    public string UserAgent { get; set; }
    [StringLength(512)]
    public  string   UserAgentOS { get; set; }
    [StringLength(512)]
    public string UserAgentDevice { get; set; }
    [StringLength(512)]
    public string UserAgentUA { get; set; }
    #endregion

    /// <summary>
    /// So'rovning ichki umumlashtirilgan manzili, o'zgarib turuvchi kalitlar umumlashtiriladi
    /// M: AppList/{id}, Users/{username}, ...
    /// </summary>
    [MaxLength(500)]
    public string NormalizedRequestPath { get; set; } = String.Empty;

    /// <summary>
    /// Xatolik sarlavhasi orqali heshlab yaratiladigan xatolik kodi
    /// M: 938c2cc0dcc05f2b68c4287040cfcf71, NULL-eski versiyalarda yozilib qolgan ma'lumotlar uchun
    /// </summary>
    [MaxLength(32)]
    public string Code { get; set; }

    /// <summary>
    /// Xatolik davri kaliti
    /// Eslatma: Arxiv jadval uchun ushbu ma'lumot NULL ko'rinishida saqlanadi
    /// </summary>
    public long? ErrorScopeId { get; set; }
}
