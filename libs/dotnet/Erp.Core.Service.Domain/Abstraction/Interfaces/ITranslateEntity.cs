using WEBASE;

namespace Erp.Core.Service.Domain;

public interface ITranslateEntity<TOwnerId, TOwnerEntity> : IWbTranslateEntity<TOwnerId>
    where TOwnerEntity : IWbEntity<TOwnerId>
    where TOwnerId : struct
{
    public TOwnerId OwnerId { get; set; }
    public Language Language { get; set; }
    public TOwnerEntity Owner { get; set; }
}
