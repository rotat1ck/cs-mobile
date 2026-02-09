using Microsoft.Extensions.Logging;
using news_app.Services;
using news_app.ViewModels;
using news_app.Views;

namespace news_app
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterAppTypes();
                

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterAppTypes(this MauiAppBuilder builder) {
            builder.Services.AddSingleton<INewsService>((services) => new NewsService());
            builder.Services.AddSingleton<INavigate>((services) => new Navigator());

            builder.Services.AddTransient<HeadlinesViewModel>();

            builder.Services.AddTransient<AboutView>();
            builder.Services.AddTransient<HeadlinesView>();
            builder.Services.AddTransient<ArticleView>();

            return builder;
        }
    }
}
