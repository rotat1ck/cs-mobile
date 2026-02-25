using mytracker.ViewModels;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace mytracker.Views;

public partial class MainView : ContentPage
{
	public MainView(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

		MainThread.BeginInvokeOnMainThread(async () => {
			var status = await AppPermissions.CheckAndRequestRequiredPermissionAsync();
			if (status == PermissionStatus.Granted) {
				var location = await Geolocation.GetLastKnownLocationAsync();

				if (location == null) {
					location = await Geolocation.GetLocationAsync();
				}

				Map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(5)));
			}
		});
	}
}