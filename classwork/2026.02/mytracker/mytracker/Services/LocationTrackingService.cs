using System;
using System.Collections.Generic;
using System.Text;

namespace mytracker.Services;

public partial class LocationTrackingService : ILocationTrackingService {
    public void StartTracking() {
        StartTrackingInternal();
    }

    partial void StartTrackingInternal();
}
