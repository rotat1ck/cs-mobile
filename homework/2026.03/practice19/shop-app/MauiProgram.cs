using Microsoft.Extensions.Logging;
using shop_app.ViewModels;
using shop_app.Views;

namespace shop_app {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MonumentExtended-Regular.ttf", "MonumentExtended");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<StoreView>();
            builder.Services.AddTransient<StoreViewModel>();

            builder.Services.AddTransient<ItemView>();
            builder.Services.AddTransient<ItemViewModel>();

            return builder.Build();
        }
    }
}
