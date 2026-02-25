using System;
using System.Collections.Generic;
using System.Text;

namespace mytracker;

public partial class AppPermissions {
    public partial class AppPermission : Permissions.LocationWhenInUse {

    }

    public static async Task<PermissionStatus> CheckRequiredPermissionAsync() =>
        await Permissions.CheckStatusAsync<AppPermission>();

    public static async Task<PermissionStatus> CheckAndRequestRequiredPermissionAsync() {
        PermissionStatus status = await Permissions.CheckStatusAsync<AppPermission>();
        if (status == PermissionStatus.Granted) {
            return status;
        }

        if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS) {
            await App.Current.MainPage.DisplayAlertAsync("Required app Permissions",
                "Please enable all permissions in Settings for this App, it is useless " +
                "without them", "Ok");
        }

        if (Permissions.ShouldShowRationale<AppPermission>()) {
            await App.Current.MainPage.DisplayAlertAsync("Required app Permissions",
                "This is a location based app, without these permission it is useless.",
                "Ok");
        }

        status = await MainThread.InvokeOnMainThreadAsync(Permissions.RequestAsync<AppPermission>);

        return status;
    }
}
