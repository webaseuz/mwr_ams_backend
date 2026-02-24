namespace Bms.WEBASE.Security;

public class UserDeviceProvider : IUserDeviceProvider
{
    public string UserIp { get; private set; }

    public string UserAgent { get; private set; }

    public void SetUserIp(string userIp)
        => UserIp = userIp;

    public void SetUserAgent(string userAgent)
        => UserAgent = userAgent;
}

