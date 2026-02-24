using AutoPark.Application.UseCases.NotificationServices;
using Quartz;

namespace AutoPark.Jobs;

public static class QuartzServiceExtension
{
    public static void ConfigureQuartzServices(this IServiceCollection services)
    {
        //0: Seconds(start at 0 seconds)
        //0: Minutes(start at 0 minutes)
        //1: Hours(run at the 1st hour, i.e., 1:00 AM)
        //*: Day of the month(every day)
        //*: Months(every month)
        //?: Day of the week(no specific day)
        //*: Years(every year)

        services.AddQuartz(q =>
        {
            if (AppSettings.Instance.QuartzDriverPenaltyNotification.Enabled)
            {
                Console.WriteLine($"DriverPenaltyNotification Service ishga tushdi. Time is {DateTime.Now}");

                var jobKey = new JobKey(AppSettings.Instance.QuartzDriverPenaltyNotification.JobKey);
                q.AddJob<NotificationWorker>(opts => opts.WithIdentity(jobKey));

                if (AppSettings.Instance.QuartzDriverPenaltyNotification.RunNow)
                {
                    q.AddTrigger(opts => opts.ForJob(jobKey)
                                             .WithIdentity(AppSettings.Instance.QuartzDriverPenaltyNotification.JobTrigger + "_now")
                                             .StartNow());
                }
                else
                {
                    q.AddTrigger(opts => opts.ForJob(jobKey)
                                             .WithIdentity(AppSettings.Instance.QuartzDriverPenaltyNotification.JobTrigger)
                                             .WithCronSchedule(AppSettings.Instance.QuartzDriverPenaltyNotification.CronSchedulePattern));
                }

            }
        });

        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);
    }
}
