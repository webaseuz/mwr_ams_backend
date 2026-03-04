namespace Erp.Core.Sdk;

public class AppHeaderHandler : DelegatingHandler
{
    private readonly AppInfoConfig _appInfoConfig;
    public AppHeaderHandler(AppInfoConfig appInfoConfig)
    {
        _appInfoConfig = appInfoConfig;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Remove(ApplicationHeaderConst.AppId);
        request.Headers.Add(ApplicationHeaderConst.AppId, _appInfoConfig.AppId.ToString());

        request.Headers.Remove(ApplicationHeaderConst.App);
        request.Headers.Add(ApplicationHeaderConst.App, _appInfoConfig.AppName);

        return base.SendAsync(request, cancellationToken);
    }
}
