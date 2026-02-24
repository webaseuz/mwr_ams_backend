namespace Bms.WEBASE.MinioSdk;

public class MinioInvalidConfigurationException : Exception
{
    public MinioInvalidConfigurationException()
    {

    }

    public MinioInvalidConfigurationException(string message)
    : base(message) { }
}
