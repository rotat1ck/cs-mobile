namespace practice6
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e) {
            if (!int.TryParse(input.Text, out int num)) {
                output2.Text = $"Введено не число";
                return;
            }

            var picker = (sender as Picker)!;
            string? result = null!;

            switch (picker.SelectedItem as string) {
                case "Двоичная": 
                    result = Convert.ToString(num, 2);
                    break;
                case "Восьмиричная":
                    result = Convert.ToString(num, 8);
                    break;
                case "Шестнадцатиричная":
                    result = Convert.ToString(num, 16);
                    break;
                
            }
            output2.Text = $"Результат: {result}";
        }

        private void entry1_TextChanged(object sender, TextChangedEventArgs e) {
            if (!double.TryParse(entry_c.Text, out double c) ||
                !double.TryParse(entry_d.Text, out double d)) {
                return;
            }
            
            List<double> res = new();
            for (int i = 1; i <= 10; ++i) {
                double a = (c + d) * i;
                double b = (c - d) * i;
                res.Add(Ample(a, b));
            }

            resultLabel.Text = $"Результат: {res.Average()}";
        }

        private double Ample(double a, double b) {
            return Math.Sqrt((int)a * 2 + (int)b * 2);
        }
    }
}
