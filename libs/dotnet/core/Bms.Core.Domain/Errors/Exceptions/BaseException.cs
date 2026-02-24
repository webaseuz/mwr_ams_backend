namespace Bms.Core.Domain;

public class BaseException : Exception
{
    public BaseException(string message) : base(message)
    { }

    public virtual ErrorType Type { get; set; }
    public ErrorCode Code { get; set; }

}
