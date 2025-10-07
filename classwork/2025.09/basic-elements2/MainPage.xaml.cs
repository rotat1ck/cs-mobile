namespace basic_elements2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void statusCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e) {
            statusLabel.Text = $"Статус: {(e.Value ? "женат/замужем" : "холост/не замужем")}";
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e) {
            RadioButton selectedButton = (RadioButton)sender;
            if (header != null) {
                header.Text = $"Выбранный язык: {selectedButton.Content}";
            }
        }

        private void langPicker_SelectedIndexChanged(object sender, EventArgs e) {
            header.Text = $"Вы выбрали путь: {langPicker.SelectedItem}";
        }
    }

}
