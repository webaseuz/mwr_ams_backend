namespace ServiceDesk.Domain.Constants;

public static class FileStorageConst
{
    public const string DEVICE_FILE = "device_files";
    public const string SERVICE_APPLICATION_FILE = "service_application_file";
    public const string SPARE_MOVEMENT_HISTORY = "spare_movemant_history";
    public const string SERVICE_APPLICATION_HISTORY = "service_application_history_files";
    public const string MOBILE_APP_VERSION = "mobile_app_version";
    public const string PERSON_FILE = "person_file";
}


public static class FileStorageConstHelper<TEntity>
    where TEntity : class
{
    public static string GetDocument()
    {
        if (typeof(TEntity) == typeof(DeviceFile))
            return FileStorageConst.DEVICE_FILE;
        else
            return null!;
    }
    public static string GetDocumenHistory()
    {
        if (typeof (TEntity) == typeof(SpareMovement))
            return FileStorageConst.SPARE_MOVEMENT_HISTORY;
        if (typeof(TEntity) == typeof(ServiceApplication))
            return FileStorageConst.SERVICE_APPLICATION_HISTORY;
        else
            return null!;
    }
}
