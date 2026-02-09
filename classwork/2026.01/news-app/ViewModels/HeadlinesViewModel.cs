using System.Web;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using news_app.Models;
using news_app.Services;

namespace news_app.ViewModels {
    public partial class HeadlinesViewModel : ViewModel {
        private readonly INewsService service;

        [ObservableProperty]
        private NewsResult currentNews;

        public HeadlinesViewModel(INewsService service, INavigate navigate) : base(navigate) {
            this.service = service;
        }

        public async Task Initialize(string scope) => await Initialize(scope.ToLower() switch {
            "local" => NewsScope.Local,
            "global" => NewsScope.Global,
            "headlines" => NewsScope.Headlines,
            _ => NewsScope.Headlines
        });

        public async Task Initialize(NewsScope scope) {
            CurrentNews = await service.GetNews(scope);
        }

        [RelayCommand]
        public async Task ItemSelected(object selectedItem) {
            var selectedArticle = selectedItem as Article;
            var url = HttpUtility.UrlEncode(selectedArticle.Url);
            await Navigation.NavigateTo($"articleview?url={url}");

        }
    }
}
