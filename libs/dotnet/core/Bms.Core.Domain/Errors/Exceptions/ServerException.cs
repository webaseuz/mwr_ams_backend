namespace Bms.Core.Domain;

public class ServerException : BaseException
{
    public ServerException(string message)
        : base(message)
    { }


    public ServerException(ErrorCode code, string message) :
        base(message)
    {
        Code = code;
    }
}

public static class ServerExceptionHelper
{

    public static ServerException Wrap(string message, ErrorCode code)
        => new ServerException(code, message);
    //...............
    /*public static ServerException InvlalidPassword()
        => Wrap($"", ErrorCode.);*/


}
