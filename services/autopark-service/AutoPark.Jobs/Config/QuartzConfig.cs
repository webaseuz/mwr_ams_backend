namespace AutoPark.Jobs;
public class QuartzConfig
{
    public bool Enabled { get; set; }
    public string JobKey { get; set; }
    public string JobTrigger { get; set; }
    public string CronSchedulePattern { get; set; }
    public bool RunNow { get; set; }
}
/*"Enabled": true,
    "JobKey": "autopark-driverpenaltynotification-Job",
    "JobTrigger": "autopark-driverpenaltynotification-trigger",
    "CronSchedulePattern": "0 0 0/2 * * ?",
    "RunNow": false*/