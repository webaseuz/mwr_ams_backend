namespace Bms.Core.Domain;

public class ClientException :
    BaseException
{
    public ClientException(string message)
        : base(message)
    { }

    public ClientException(ErrorCode code, string message) :
        base(message)
    {
        Code = code;
    }
}