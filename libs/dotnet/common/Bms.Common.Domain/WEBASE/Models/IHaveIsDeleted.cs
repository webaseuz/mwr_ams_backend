namespace Bms.WEBASE.Models;

public interface IHaveIsDeleted
{
    bool IsDeleted { get; set; }
}

public interface ISoftDeletable
{
    bool IsDeleted { get; }
    void MarkAsDeleted();
}