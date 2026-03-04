using System.Reflection;
using WEBASE;

namespace Erp.Core;
public static class TableIdConst
{
    #region ADM

    public const int ADM_ENUM_LANGUAGE = 2;
    public const int ADM_ENUM_STATE = 3;
    public const int ADM_ENUM_STATE_TRANSLATE = 4;
    public const int ADM_ENUM_STATUS = 5;
    public const int ADM_ENUM_STATUS_TRANSLATE = 6;
    public const int ADM_ENUM_GENDER = 10;
    public const int ADM_ENUM_GENDER_TRANSLATE = 11;
    public const int ADM_SELECT_QUERIES = 13;
    public const int ADM_SYS_PERMISSION_GROUP = 14;
    public const int ADM_SYS_PERMISSION_GROUP_TRANSLATE = 15;
    public const int ADM_SYS_PERMISSION_SUB_GROUP = 16;
    public const int ADM_SYS_PERMISSION_SUB_GROUP_TRANSLATE = 17;
    public const int ADM_SYS_PERMISSION = 18;
    public const int ADM_SYS_PERMISSION_TRANSLATE = 19;
    public const int ADM_INFO_CITIZENSHIP = 20;
    public const int ADM_INFO_NATIONALITY = 21;
    public const int ADM_ENUM_APP = 22;
    public const int ADM_SYS_ROLE = 23;
    public const int ADM_SYS_ROLE_PERMISSION = 24;
    public const int ADM_INFO_CURRENCY = 26;
    public const int ADM_ENUM_APP_TRANSLATE = 27;
    public const int ADM_INFO_COUNTRY = 34;
    public const int ADM_INFO_COUNTRY_TRANSLATE = 35;
    public const int ADM_INFO_CURRENCY_TRANSLATE = 37;
    public const int ADM_INFO_NATIONALITY_TRANSLATE = 38;
    public const int ADM_INFO_CITIZENSHIP_TRANSLATE = 40;
    public const int ADM_HL_PERSON = 42;
    public const int ADM_SYS_USER = 43;
    public const int ADM_SYS_USER_ROLE = 44;
    public const int ADM_INFO_REGION = 46;
    public const int ADM_ENUM_INFO_REGION_TRANSLATE = 47;
    public const int ADM_INFO_DISTRICT_GROUP = 49;
    public const int ADM_INFO_DISTRICT = 50;
    public const int ADM_ENUM_ORGANIZATIONAL_FORM = 51;
    public const int ADM_INFO_DISTRICT_TRANSLATE = 52;
    public const int ADM_ENUM_ORGANIZATIONAL_FARM = 53;
    public const int ADM_INFO_ORGANIZATION_TYPE = 56;
    public const int ADM_INFO_BANK = 57;
    public const int ADM_INFO_BANK_TRANSLATE = 58;
    public const int ADM_INFO_OKED = 59;
    public const int ADM_INFO_INSTITUTION_TYPE = 61;
    public const int ADM_INFO_EDU_YEAR = 65;
    public const int ADM_INFO_EDU_YEAR_TRANSLATE = 66;
    public const int ADM_INFO_MFY = 67;
    public const int ADM_INFO_ORGANIZATION = 68;
    public const int ADM_SYS_USER_ORGANIZATION = 70;
    public const int ADM_INFO_ORGANIZATION_ACCOUNT = 71;
    public const int ADM_INFO_ORGANIZATION_CADASTRE_CERTIFICATE = 72;
    public const int ADM_INFO_ORGANIZATION_SPECIALIZATION = 73;
    public const int ADM_HL_PERSON_HISTORY = 78;
    public const int ADM_HL_PERSON_ADDRESS = 79;
    public const int ADM_HL_PERSON_ADDRESS_HISTORY = 80;
    public const int ADM_ENUM_FILE_TYPE = 197;
    public const int ADM_SYS_FILE_CONFIG = 198;
    public const int ADM_SYS_FILE_CONFIG_TABLE = 199;
    public const int ADM_ENUM_FILE_CONFIG_PERMISSION_ACTION = 200;
    public const int ADM_SYS_FILE_CONFIG_PERMISSION = 201;
    public const int ADM_SYS_DOCUMENT_FILE = 202;
    public const int ADM_ENUM_CALCULATE_BY_TIME_TYPE = 394;
    public const int ADM_ENUM_CALCULATE_BY_TIME_TYPE_TRANSLATE = 395;
    public const int ADM_ENUM_CALCULATION_METHOD = 396;
    public const int ADM_ENUM_CALCULATION_METHOD_TRANSLATE = 397;
    public const int ADM_ENUM_CALCULATION_TYPE = 398;
    public const int ADM_ENUM_CALCULATION_TYPE_TRANSLATE = 399;
    public const int ADM_ENUM_DISTRICT_GROUP = 400;
    public const int ADM_ENUM_DOCUMENT_TYPE = 401;
    public const int ADM_ENUM_EMPLOYMENT_TYPE = 402;
    public const int ADM_ENUM_EMPLOYMENT_TYPE_TRANSLATE = 403;
    public const int ADM_ENUM_EXTERNAL_STATUS = 404;
    public const int ADM_ENUM_EXTERNAL_STATUS_TRANSLATE = 405;
    public const int ADM_ENUM_EXTERNAL_SYSTEM = 406;
    public const int ADM_ENUM_EXTERNAL_SYSTEM_TRANSLATE = 407;
    public const int ADM_ENUM_KINSHIP_DEGREE = 409;
    public const int ADM_ENUM_MINIMUM_VALUE_TYPE = 410;
    public const int ADM_ENUM_MINIMUM_VALUE_TYPE_TRANSLATE = 411;
    public const int ADM_ENUM_ORGANIZATIONAL_FORM_TRANSLATE = 412;
    public const int ADM_ENUM_TEMPORARY_RESIDENCE_TYPE = 413;
    public const int ADM_ENUM_TEMPORARY_RESIDENCE_TYPE_TRANSLATE = 414;
    public const int ADM_INFO_CALCULATION_KIND = 415;
    public const int ADM_INFO_CALCULATION_KIND_ALLOWED_DOC = 416;
    public const int ADM_INFO_CALCULATION_KIND_PERCENT = 417;
    public const int ADM_INFO_CALCULATION_KIND_TRANSLATE = 418;
    public const int ADM_INFO_CALCULATION_KIND_USED_TABLE = 419;
    public const int ADM_INFO_DOCUMENT_STATUS = 420;
    public const int ADM_INFO_DOCUMENT_STATUS_TABLE = 421;
    public const int ADM_INFO_EDU_DIRECTION = 422;
    public const int ADM_INFO_EDU_DIRECTION_TRANSLATE = 423;
    public const int ADM_INFO_FIXED_MINIMUM_VALUE = 424;
    public const int ADM_INFO_INSTITUTION_TYPE_TRANSLATE = 425;
    public const int ADM_INFO_ITEM_OF_EXPENSE = 426;
    public const int ADM_INFO_ITEM_OF_EXPENSE_TRANSLATE = 427;
    public const int ADM_INFO_OKED_TRANSLATE = 428;
    public const int ADM_INFO_ORGANIZATION_ACCOUNT_TRANSLATE = 429;
    public const int ADM_INFO_ORGANIZATION_CADASTRE_CERTIFICATE_TRANSLATE = 430;
    public const int ADM_INFO_ORGANIZATION_SPECIALIZATION_TRANSLATE = 431;
    public const int ADM_INFO_ORGANIZATION_TRANSLATE = 432;
    public const int ADM_INFO_ORGANIZATION_TYPE_TRANSLATE = 433;
    public const int ADM_INFO_REGION_TRANSLATE = 434;
    public const int ADM_INFO_SPECIALTY = 435;
    public const int ADM_INFO_SPECIALTY_TRANSLATE = 436;
    public const int ADM_INFO_UNIT_OF_MEASURE = 437;
    public const int ADM_INFO_UNIT_OF_MEASURE_TRANSLATE = 438;
    public const int ADM_SYS_DOCUMENT_CHANGE_LOG = 439;
    public const int ADM_SYS_DOCUMENT_HISTORY = 440;
    public const int ADM_SYS_EXTERNAL_DATA = 441;
    public const int ADM_SYS_FILE_CONFIG_TRANSLATE = 442;
    public const int ADM_SYS_ROLE_POSITION = 443;
    public const int ADM_SYS_ROLE_TRANSLATE = 444;
    public const int ADM_SYS_TABLE = 445;
    public const int ADM_SYS_TABLE_TRANSLATE = 446;
    public const int ADM_ENUM_MUSIC_ORGANIZATION_CATEGORY = 574;
    public const int ADM_ENUM_MUSIC_ORGANIZATION_CATEGORY_TRANSLATE = 575;
    public const int ADM_ENUM_CUSTOM_JOB_TYPE = 676;
    public const int ADM_ENUM_CUSTOM_JOB_TYPE_TRANSLATE = 677;
    public const int ADM_SYS_CUSTOM_JOB = 678;
    public const int ADM_SYS_CUSTOM_JOB_ACTION = 679;

    public const int ADM_ENUM_ENDPOINT_TYPE = 746;
    public const int ADM_ENUM_ENDPOINT_TYPE_TRANSLATE = 747;
    public const int ADM_INFO_EXTERNAL_SYSTEM_ENDPOINT = 748;
    public const int ADM_INFO_EXTERNAL_SYSTEM_ENDPOINT_TABLE = 749;

    #endregion

    public static string GetTableNameWithId(int tableId)
    {
        var fields = typeof(TableIdConst).GetFields(BindingFlags.Public | BindingFlags.Static).ToList();

        var field = fields.FirstOrDefault(f => (int)f.GetValue(null) == tableId);

        if (field == null)
            throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure { Key = "TABLE_NAME_NOT_FOUND", ErrorMessage = "Table topilmadi." });

        return field.Name;
    }

    public static string GetFirstPrefix(this string input, char separator = '_')
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        int index = input.IndexOf(separator);
        return index >= 0 ? input.Substring(0, index) : input;
    }

}
