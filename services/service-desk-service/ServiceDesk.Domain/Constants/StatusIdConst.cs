namespace ServiceDesk.Domain.Constants;

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
    public const int IN_PROCESS = 9;
    public const int FINISHED = 10;
    public const int FINISHED_BY_EXECUTOR = 11;
    public const int CANCELED_BY_CLIENT = 12;
    public const int CANCELED_BY_EXECUTOR = 13;
    public const int WAIT_SPARES = 14;
    public const int FAILED = 15;
    
    #region DOCUMENTS
    public static bool CanServiceApplicationStatus(int currentStatusId, int newStatusId)
    {
        return newStatusId switch
        {
            CREATED => new int[] { 0 }.Contains(currentStatusId),
            MODIFIED => new int[] { CREATED, MODIFIED, REVOKED, IN_PROCESS, CANCELED_BY_CLIENT, CANCELED_BY_EXECUTOR }.Contains(currentStatusId),
            DELETED => new int[] { CREATED, MODIFIED, REVOKED }.Contains(currentStatusId),
            SEND => new int[] { CREATED, MODIFIED }.Contains(currentStatusId),
            REVOKED => new int[] { SEND }.Contains(currentStatusId),
            //CANCELLED => new int[] { SEND, IN_PROCESS }.Contains(currentStatusId),
            IN_PROCESS => new int[] { SEND, CANCELED_BY_CLIENT, WAIT_SPARES }.Contains(currentStatusId),
            FINISHED => new int[] { FINISHED_BY_EXECUTOR }.Contains(currentStatusId),
            FINISHED_BY_EXECUTOR => new int[] { IN_PROCESS }.Contains(currentStatusId),
            CANCELED_BY_CLIENT => new int[] { FINISHED_BY_EXECUTOR }.Contains(currentStatusId),
            CANCELED_BY_EXECUTOR => new int[] { SEND, IN_PROCESS }.Contains(currentStatusId),
            WAIT_SPARES => new int[] { IN_PROCESS }.Contains(currentStatusId),
            FAILED => new int[] { CANCELED_BY_EXECUTOR }.Contains(currentStatusId),
            _ => false,
        };
    }

    public static bool CanSpareMovementStatus(int currentStatusId, int newStatusId)
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
    public static bool CanNotificationTemplateSettingStatus(int currentStatusId, int newStatusId)
    {
        return newStatusId switch
        {
            CREATED => new int[] { 0 }.Contains(currentStatusId),
            MODIFIED => new int[] { CREATED, MODIFIED }.Contains(currentStatusId),
            DELETED => new int[] { CREATED, MODIFIED, CANCELLED}.Contains(currentStatusId),
            ACCEPTED => new int[] { CREATED, MODIFIED }.Contains(currentStatusId),
            CANCELLED => new int[] { ACCEPTED }.Contains(currentStatusId),
            _ => false,
        };
    }
    #endregion
}
