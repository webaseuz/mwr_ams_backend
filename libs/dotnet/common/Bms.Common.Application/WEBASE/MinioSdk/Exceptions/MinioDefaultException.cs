namespace Bms.WEBASE.MinioSdk;

public class MinioDefaultException : Exception
{
    public MinioDefaultException()
    {

    }

    public MinioDefaultException(string message)
    : base(message) { }
}
