namespace Bms.WEBASE.Extensions;

public static class ExceptionExtensions
{
    public static Exception GetInnermostException(this Exception exception)
    {
        if (exception.InnerException == null)
        {
            return exception;
        }

        return exception.InnerException.GetInnermostException();
    }
}
