namespace Erp.Core;

public class AppInfoConfig
{
    public int AppId { get; }
    public string AppName { get; }
    public AppType AppType { get; }

    public AppInfoConfig(int appId, AppType appType)
    {
        AppId = appId;
        AppType = appType;
        AppName = AppIdConst.GetStringById(appId);
    }
}
