namespace datepicker__timepicker
{
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        void DateSelected(object sender, DateChangedEventArgs e) {
            if (label is { })
                label.Text = $"Вы выбрали {e.NewDate.ToString("d")}";
        }
    }
}
