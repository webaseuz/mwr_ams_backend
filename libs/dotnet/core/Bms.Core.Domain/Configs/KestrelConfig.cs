namespace Bms.Core.Domain;

public class KestrelConfig
{
    public KestrelEndpoint Endpoints { get; set; } = new();
}

public class KestrelEndpoint
{
    public KestrelProtocol Http1 { get; set; } = new();
    public KestrelProtocol Http2 { get; set; } = new();
}


public class KestrelProtocol
{
    public int Port { get; set; }
}


