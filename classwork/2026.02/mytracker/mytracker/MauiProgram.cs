using Microsoft.Extensions.Logging;
using mytracker.Repositories;
using mytracker.Services;
using mytracker.ViewModels;

namespace mytracker {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ILocationRepository, LocationRepository>();
            builder.Services.AddSingleton<ILocationTrackingService, LocationTrackingService>();
            builder.Services.AddTransient<MainViewModel>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
