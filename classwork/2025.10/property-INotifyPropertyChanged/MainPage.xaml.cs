namespace property_INotifyPropertyChanged {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e) {
            var user = Resources["user"] as User;
            user.Age++;
        }
    }
}
