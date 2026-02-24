namespace Bms.WEBASE.Security;

public interface IUserDeviceProvider
{
    string UserIp { get; }

    string UserAgent { get; }

    void SetUserIp(string userId);

    void SetUserAgent(string userAgent);
}
