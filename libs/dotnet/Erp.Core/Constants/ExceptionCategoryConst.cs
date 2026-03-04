namespace Erp.Core;

public class ExceptionCategoryConst
{
    // HTTP va API xatolari
    public const string HTTP_ERROR = "HTTP_ERROR";
    public const string API_ERROR = "API_ERROR";
    public const string CLIENT_ERROR = "CLIENT_ERROR";
    public const string SERVER_ERROR = "SERVER_ERROR";

    // Network va ulanish xatolari
    public const string NETWORK_ERROR = "NETWORK_ERROR";
    public const string TIMEOUT_ERROR = "TIMEOUT_ERROR";
    public const string CONNECTION_ERROR = "CONNECTION_ERROR";

    // Validatsiya xatolari
    public const string VALIDATION_ERROR = "VALIDATION_ERROR";
    public const string INPUT_ERROR = "INPUT_ERROR";
    public const string BUSINESS_RULE_ERROR = "BUSINESS_RULE_ERROR";

    // Database xatolari
    public const string DATABASE_ERROR = "DATABASE_ERROR";
    public const string DATA_ACCESS_ERROR = "DATA_ACCESS_ERROR";
    public const string CONCURRENCY_ERROR = "CONCURRENCY_ERROR";

    // Avtorizatsiya va authentication
    public const string AUTHENTICATION_ERROR = "AUTHENTICATION_ERROR";
    public const string AUTHORIZATION_ERROR = "AUTHORIZATION_ERROR";
    public const string PERMISSION_ERROR = "PERMISSION_ERROR";

    // Tizim xatolari
    public const string SYSTEM_ERROR = "SYSTEM_ERROR";
    public const string CONFIGURATION_ERROR = "CONFIGURATION_ERROR";
    public const string DEPENDENCY_ERROR = "DEPENDENCY_ERROR";

    // E-gov maxsus kategoriyalar
    public const string EGOV_SERVICE_ERROR = "EGOV_SERVICE_ERROR";
    public const string EXTERNAL_SERVICE_ERROR = "EXTERNAL_SERVICE_ERROR";
    public const string INTEGRATION_ERROR = "INTEGRATION_ERROR";

    // Kutilmagan xatolari
    public const string UNEXPECTED_ERROR = "UNEXPECTED_ERROR";
    public const string UNKNOWN_ERROR = "UNKNOWN_ERROR";

    // JSON va Serialization xatolari
    public const string JSON_PARSE_ERROR = "JSON_PARSE_ERROR";
    public const string JSON_SERIALIZATION_ERROR = "JSON_SERIALIZATION_ERROR";
    public const string JSON_DESERIALIZATION_ERROR = "JSON_DESERIALIZATION_ERROR";
    public const string JSON_FORMAT_ERROR = "JSON_FORMAT_ERROR";
    public const string JSON_CONVERSION_ERROR = "JSON_CONVERSION_ERROR";

    // File va Data format xatolari
    public const string FILE_FORMAT_ERROR = "FILE_FORMAT_ERROR";
    public const string DATA_FORMAT_ERROR = "DATA_FORMAT_ERROR";
    public const string ENCODING_ERROR = "ENCODING_ERROR";
}
