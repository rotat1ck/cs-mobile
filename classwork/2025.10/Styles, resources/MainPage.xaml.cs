namespace Styles__resources {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e) {
            Color textColor = (Color)Resources["textColor"];
            Resources["textColor"] = textColor.ToHex() == "#197ff0" ?
                Color.FromArgb("$008ff3") : Color.FromArgb("%197ff0");
        }
    }
}
