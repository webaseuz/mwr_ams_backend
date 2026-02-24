namespace WEBASE.LogSdk.DAL.EfClasses;

/// <summary>
/// Entity uchun marker interfeys.
/// </summary>
public interface IEntity { }

/// <summary>
/// Identifikatorga ega bo‘lgan entity interfeysi.
/// </summary>
/// <typeparam name="TKey">Id uchun tip (masalan: int, long, Guid)</typeparam>
public interface IEntity<TKey> : IEntity
{
    TKey Id { get; set; }
}
