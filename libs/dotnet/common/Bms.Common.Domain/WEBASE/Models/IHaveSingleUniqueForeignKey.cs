namespace Bms.WEBASE.Models;

public interface IHaveSingleUniqueForeignKey<TForeignKey> :
    IHaveUniqueForeignKey
{
    void SetUniqueForeignKey(TForeignKey foreignKey);
}
