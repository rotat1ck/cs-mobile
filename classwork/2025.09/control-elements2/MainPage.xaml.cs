namespace control_elements2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e) {
           /// label1.Text = entry1.Text;
        }

        private void Button_Clicked(object sender, EventArgs e) {
            label1.TextColor = Color.FromRgba(0, 255, 255, 0.8);
        }
    }
}
