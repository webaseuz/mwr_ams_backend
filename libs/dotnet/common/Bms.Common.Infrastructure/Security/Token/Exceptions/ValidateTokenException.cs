namespace Bms.WEBASE.Security;

public class ValidateTokenException : Exception
{
    public ValidateTokenException(string message) :
        base(message)
    { }
}
