namespace Bms.WEBASE.Models;

public interface IHaveStateId
{
    int StateId { get; set; }
}

public interface IHaveSoftStateId
{
    int StateId { get; }
    void MarkAsPassive();
    void MarkAsActive();
}