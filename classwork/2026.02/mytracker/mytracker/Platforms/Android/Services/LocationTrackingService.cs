using Android.App.Job;
using Android.Content;
using mytracker.Services;

namespace mytracker.Platforms.Android.Services;

public partial class LocationTrackingService : ILocationTrackingService {
    public partial void StartTrackingInternal() {
        var javaClass = Java.Lang.Class.FromType(typeof(LocationJobService));
        var componentName = new ComponentName(global::Android.App.Application.Context,
            javaClass);
        var jobBuilder = new JobInfo.Builder(1, componentName);

        jobBuilder.SetOverrideDeadline(1000);
        jobBuilder.SetPersisted(true);
        jobBuilder.SetRequiresDeviceIdle(false);
        jobBuilder.SetRequiresStorageNotLow(true);

        var jobInfo = jobBuilder.Build();

        var jobScheduler = (JobScheduler)global::Android.App.Application.Context.
            GetSystemService(Context.JobSchedulerService);

        jobScheduler.Schedule(jobInfo);
    }
}


