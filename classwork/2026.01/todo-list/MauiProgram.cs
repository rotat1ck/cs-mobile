using Microsoft.Extensions.Logging;
using todo_list.Repositories;
using todo_list.ViewModels;
using todo_list.Views;

namespace todo_list {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder
                .RegisterService()
                .RegisterViewModels()
                .RegisterViews();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterService(this MauiAppBuilder builder) {
            builder.Services.AddSingleton<ITodoItemRepository, TodoItemRepository>();

            return builder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder) {
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<ItemViewModel>();

            return builder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder) {
            builder.Services.AddSingleton<MainView>();
            builder.Services.AddSingleton<ItemView>();

            return builder;
        }
    }
}
