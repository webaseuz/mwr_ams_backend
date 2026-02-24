namespace AutoPark.Domain.Constants;

public static class FileStorageConst
{
    public const string TRANSPORT_SETTING_HISTORY = "transport_setting_history_files";
    public const string TRANSPORT_SETTING_FILE = "transport_setting_files";
    public const string REFUEL_HISTORY = "refuel_history_files";
    public const string REFUEL_FILE = "refuel_file";
    public const string EXPENSE_HISTORY = "expense_history_files";
    public const string EXPENSE_FILE = "expense_file";
    public const string DRIVER_DOCUMENT_FILE = "driver_document_files";
    public const string TRANSPORT_FILE = "transport_files";
    public const string TRANSPORT_MODEL_FILE = "transport_model_files";
    public const string PERSON_FILE = "person_file";
    public const string MOBILE_APP_VERSION = "mobile_app_version";
    public const string EXPENSE_BATTERY_FILE = "expense_battery_file";
    public const string EXPENSE_INCPECTION_FILE = "expense_inspection_file";
    public const string EXPENSE_INSURANCE_FILE = "expense_insurance_file";
    public const string EXPENSE_OIL_FILE = "expense_oil_file";
    public const string EXPENSE_LIQUID_FILE = "expense_liquid_file";
    public const string EXPENSE_TIRE_FILE = "expense_tire_file";
}


public static class FileStorageConstHelper<TEntity>
    where TEntity : class
{
    public static string GetDocument()
    {
        if (typeof(TEntity) == typeof(TransportSettingHistory))
            return FileStorageConst.TRANSPORT_SETTING_HISTORY;
        if (typeof(TEntity) == typeof(RefuelHistory))
            return FileStorageConst.REFUEL_HISTORY;
        if (typeof(TEntity) == typeof(RefuelFile))
            return FileStorageConst.REFUEL_FILE;
        if (typeof(TEntity) == typeof(ExpenseHistory))
            return FileStorageConst.EXPENSE_HISTORY;
        if (typeof(TEntity) == typeof(ExpenseFile))
            return FileStorageConst.EXPENSE_FILE;
        if (typeof(TEntity) == typeof(TransportFile))
            return FileStorageConst.TRANSPORT_FILE;
        if (typeof(TEntity) == typeof(TransportModelFile))
            return FileStorageConst.TRANSPORT_MODEL_FILE;
        if (typeof(TEntity) == typeof(DriverDocument))
            return FileStorageConst.DRIVER_DOCUMENT_FILE;
        if (typeof(TEntity) == typeof(TransportSettingFile))
            return FileStorageConst.TRANSPORT_SETTING_FILE;
        else
            return null!;
    }

    public static string GetDocumenHistory()
    {
        if (typeof(TEntity) == typeof(Refuel))
            return FileStorageConst.REFUEL_HISTORY;
        if (typeof(TEntity) == typeof(Expense))
            return FileStorageConst.EXPENSE_HISTORY;
        if (typeof(TEntity) == typeof(TransportSetting))
            return FileStorageConst.TRANSPORT_SETTING_HISTORY;
        else
            return null!;
    }
}