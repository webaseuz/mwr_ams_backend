namespace Bms.Core.Domain;

public class ErrorParser
{
    public static ErrorType GetErrorType(ErrorCode code)
    {
        int val = (int)code;

        if (val > 3000)
            return ErrorType.SERVER;
        else
            return ErrorType.CLIENT;
    }

    public static ErrorLevel GetErrorLevel(ErrorCode code)
    {
        int val = (int)code;

        if (val > 1000 && val < 6000)
            return ErrorLevel.INFO;
        else
            return ErrorLevel.ERROR;
    }
}
