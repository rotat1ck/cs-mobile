namespace navigation {
    public partial class MainPage : ContentPage {
        // NavigationStack - not modal pages
        // ModalStack - modal pages

        // RemovePage
        // InsertPageBefore(pageA, pageB)
        // PopToRootAsync()

        Label stacklabel;
        bool loaded = false;

        public MainPage() {
            //InitializeComponent();
            Title = "Main";
            Button toCommon = new Button {
                Text = "Common",
                HorizontalOptions = LayoutOptions.Start,
            };
            toCommon.Clicked += ToCommonPage;

            Button toModal = new Button {
                Text = "Modal",
                HorizontalOptions = LayoutOptions.Start,
            };
            toModal.Clicked += ToModalPage;

            Button forward = new Button { Text = "Вперед" };
            forward.Clicked += ToForward;
            stacklabel = new Label();


            Content = new StackLayout { 
                Children = { 
                    toCommon, toModal, 
                    forward, stacklabel 
                } 
            };
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            if (!loaded) {
                DisplayStack();
                loaded = true;
            }
        }

        protected internal void DisplayStack() {
            if (Application.Current?.MainPage is NavigationPage navPage) {
                stacklabel.Text = "";
                foreach (Page p in navPage.Navigation.NavigationStack) {
                    stacklabel.Text = $"{p.Title}\n{stacklabel.Text}";
                }
            }
        }

        private async void ToForward(object? sender, EventArgs e) {
            Page2 page = new Page2();
            await Navigation.PushAsync(page);
            DisplayStack();
        }

        private async void ToCommonPage(object? sender, EventArgs e) {
            await Navigation.PushAsync(new Common(), true);
        }

        private async void ToModalPage(object? sender, EventArgs e) {
            await Navigation.PushModalAsync(new Modal(), true);
        }
    }
}
