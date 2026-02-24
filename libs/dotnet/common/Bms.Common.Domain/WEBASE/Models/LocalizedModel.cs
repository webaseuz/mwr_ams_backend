namespace Bms.WEBASE.Models;

public class LocalizedModel
{
    public LocalizedModel()
    {

    }
    public CultureModel Culture { get; set; }
    public string ErrorCode { get; set; }
    public string Text { get; set; }
    public string Description { get; set; }
}
