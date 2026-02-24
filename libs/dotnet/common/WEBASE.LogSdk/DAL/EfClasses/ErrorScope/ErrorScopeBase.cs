using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WEBASE.Models;

namespace WEBASE.LogSdk.DAL.EfClasses;

/// <summary>
/// Har bir xatolikni kunlik davr mobaynida nech marta chiqqanligi va holati haqida ma'lumot beradi
/// </summary>
public abstract class ErrorScopeBase : IHaveIdProp<long>, IEntity<long>
{
    /// <summary>
    /// Har bir qator uchun birlamchi kalit
    /// M: 1, 2, 3 ..
    /// </summary>
    [Key]
    public long Id { get; set; }

    /// <summary>
    /// Tizim ishlab turgan host ma'lumotlarini oladi
    /// M: organization.com, 101.101.101.101:80, ...
    /// </summary>
    [MaxLength(100)]
    [Required]
    public string HostName { get; set; } = null!;

    /// <summary>
    /// So'rovning ichki umumlashtirilgan manzili, o'zgarib turuvchi kalitlar umumlashtiriladi
    /// M: AppList/{id}, Users/{username}, ...
    /// </summary>
    [MaxLength(500)]
    public string NormalizedRequestPath { get; set; } = String.Empty;

    /// <summary>
    /// Xatolik turi
    /// M: NullReferenceException, StackOverflowException
    /// </summary>
    [MaxLength(250)]
    public string Type { get; set; }

    /// <summary>
    /// Xatolik sarlavhasi
    /// M: Object reference not set to an instance of an object
    /// </summary>
    [MaxLength(2000)]
    public string Title { get; set; }

    /// <summary>
    /// Xatolik sarlavhasi orqali heshlab yaratiladigan xatolik kodi
    /// M: 938c2cc0dcc05f2b68c4287040cfcf71
    /// </summary>
    [Required]
    [MaxLength(32)]
    public string Code { get; set; } = String.Empty;

    /// <summary>
    /// Xatolik holati haqida
    /// TRUE - hal qilingan, FALSE - hal qilinmagan, NULL - urinish bo'lmagan
    /// </summary>
    public bool? IsFixed { get; set; }

    /// <summary>
    /// Davr interval vaqt kaliti (yyyy_MM_dd)
    /// M: 2024_11_21
    /// </summary>
    [Required]
    [MaxLength(10)]
    public string ScopeKey { get; set; } = String.Empty;

    /// <summary>
    /// Sodir bo'lgan vaqt
    /// </summary>
    [JsonConverter(typeof(DateTimeConverter))]
    [Required]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Oxirgi marta o'zgartirilgan vaqt
    /// </summary>
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? ModifiedAt { get; set; }
}