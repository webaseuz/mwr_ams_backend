namespace WEBASE.LogSdk.BLL.Services;
public class ErrorScopeDashboardDto
{
    public HashSet<string> ExistServices { get; set; } = new();
    public List<ErrorScopeDashboardDivisionDto> Divisions { get; set; } = new();
}

public class ErrorScopeDashboardDivisionDto
{
    public string Host { get; set; } = String.Empty;

    public int ErrorCount { get; set; }
    public double ErrorPercent { get; set; }

    public int ErrorFixedCount { get; set; }
    public double ErrorFixedPercent { get; set; }

    public int ErrorNotFixedCount { get; set; }
    public double ErrorNotFixedPercent { get; set; }
}
