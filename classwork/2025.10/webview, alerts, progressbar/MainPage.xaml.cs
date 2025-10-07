namespace webview {
    public partial class MainPage : ContentPage {
        Label statusLabel = new Label() { Padding = 8, FontSize = 20 };
        Label actionLabel;
        Label nameLabel;
        ProgressBar progressBar;
        Label progressBarLabel;

        public MainPage() {
            //InitializeComponent();
            //Grid grid = new Grid();
            //grid.RowDefinitions.Add(new RowDefinition { Height = 60 });
            //grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            //WebView webView = new WebView();
            //webView.Source = "https://google.com";
            //webView.Navigated += (object s, WebNavigatedEventArgs e) => {
            //    if (e.Result == WebNavigationResult.Success) {
            //        statusLabel.Text = "Запрос завершился успешно";
            //    } else {
            //        statusLabel.Text = "В процессе запроса возникли проблемы";
            //    }
            //};

            //grid.Add(statusLabel, 0, 0);
            //grid.Add(webView, 0, 1);
            //Content = grid;

            Button button = new Button {
                Text = "OK",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
            };
            button.Clicked += AlertButton_Clicked!;


            Button alert = new Button {
                Text = "Alert",
                HorizontalOptions = LayoutOptions.Center
            };
            alert.Clicked += AlBut!;
            actionLabel = new Label();


            Button alert2 = new Button {
                Text = "Alert2",
                HorizontalOptions = LayoutOptions.Center
            };
            nameLabel = new Label();
            alert2.Clicked += async (object sender, EventArgs e) => {
                var name = await DisplayPromptAsync("Логин", "Введите имя", "OK", "Отмена");
                nameLabel.Text = name;
            }
            !;

            progressBar = new ProgressBar {
                ProgressColor = Colors.DarkSeaGreen
            };
            progressBarLabel = new Label();

            StackLayout stack = new StackLayout { Padding = 20 };
            stack.Children.Add(progressBar);
            stack.Children.Add(progressBarLabel);

            Content = new StackLayout { Children = { button, alert, actionLabel, alert2, nameLabel, stack } };

        }

        protected override async void OnAppearing() {
            while (progressBar.Progress < 0.9) {
                progressBar.Progress += 0.1;
                progressBarLabel.Text = $"Состояние процесса: {Math.Round(progressBar.Progress, 1) * 100} %";
                await Task.Delay(1000);
            }
            progressBarLabel.Text = "Процесс окончен";
            base.OnAppearing();
        }

        async void AlBut(object sender, EventArgs e) {
            var action = await DisplayActionSheet("Выбрать язык", null, null, "C#", "JS", "C++", "C");
            actionLabel.Text = action;
        }
        async void AlertButton_Clicked(object sender, EventArgs e) {
            //await DisplayAlert("Уведомление", "Пришло новое сообщение", "ОК");
            bool res = await DisplayAlert("Подтвердите выбор", "Вы хотите удалить элемент", "Да", "Нет");
            await DisplayAlert("Уведомление", $"Вы выбрали {(res ? "Удалить" : "Отменить")}", "Ок");
        }
    }
}
