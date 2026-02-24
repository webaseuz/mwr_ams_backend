namespace AutoPark.Domain.Constants;

public class StatusIdConst
{
    public const int CREATED = 1;
    public const int MODIFIED = 2;
    public const int ACCEPTED = 3;
    public const int CANCELLED = 4;
    public const int DELETED = 5;
    public const int REVOKED = 6;
    public const int SEND = 7;
    public const int HELD = 8;


    #region DOCUMENTS
    public static bool CanTransportSettingStatus(int currentStatusId, int newStatusId)
    {
        return newStatusId switch
        {
            CREATED => new int[] { 0 }.Contains(currentStatusId),
            ACCEPTED => new int[] { CREATED, MODIFIED }.Contains(currentStatusId),
            MODIFIED => new int[] { CREATED, MODIFIED, CANCELLED }.Contains(currentStatusId),
            DELETED => new int[] { CREATED, MODIFIED }.Contains(currentStatusId),
            CANCELLED => new int[] { ACCEPTED }.Contains(currentStatusId),
            _ => false,
        };
    }

    public static bool CanRefuelStatus(int currentStatusId, int newStatusId)
    {
        return newStatusId switch
        {
            CREATED => new int[] { 0 }.Contains(currentStatusId),
            MODIFIED => new int[] { CREATED, MODIFIED, CANCELLED, REVOKED }.Contains(currentStatusId),
            DELETED => new int[] { CREATED, MODIFIED }.Contains(currentStatusId),
            SEND => new int[] { CREATED, MODIFIED }.Contains(currentStatusId),
            REVOKED => new int[] { SEND }.Contains(currentStatusId),
            ACCEPTED => new int[] { CREATED, MODIFIED, SEND }.Contains(currentStatusId),
            CANCELLED => new int[] { ACCEPTED }.Contains(currentStatusId),
            _ => false,
        };
    }

    public static bool CanExpenseStatus(int currentStatusId, int newStatusId)
    {
        return newStatusId switch
        {
            CREATED => new int[] { 0 }.Contains(currentStatusId),
            MODIFIED => new int[] { CREATED, MODIFIED, REVOKED, CANCELLED }.Contains(currentStatusId),
            DELETED => new int[] { CREATED, MODIFIED, REVOKED }.Contains(currentStatusId),
            SEND => new int[] { CREATED, MODIFIED }.Contains(currentStatusId),
            REVOKED => new int[] { SEND }.Contains(currentStatusId),
            ACCEPTED => new int[] { SEND }.Contains(currentStatusId),
            CANCELLED => new int[] { ACCEPTED }.Contains(currentStatusId),
            _ => false,
        };
    }

    public static bool CanInvoice(int currentStatusId)
    {
        return currentStatusId switch
        {
            SEND => true,
            _ => false,
        };
    }


    public static bool CanNotificationTemplateSettingStatus(int currentStatusId, int newStatusId)
    {
        return newStatusId switch
        {
            CREATED => new int[] { 0 }.Contains(currentStatusId),
            MODIFIED => new int[] { CREATED, MODIFIED }.Contains(currentStatusId),
            DELETED => new int[] { CREATED, MODIFIED, }.Contains(currentStatusId),
            ACCEPTED => new int[] { CREATED, MODIFIED }.Contains(currentStatusId),
            CANCELLED => new int[] { ACCEPTED }.Contains(currentStatusId),
            _ => false,
        };
    }

    #endregion
}
