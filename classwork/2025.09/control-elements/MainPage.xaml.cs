namespace control_elements
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        public void ClickButton(object sender, EventArgs e) {
            Environment.Exit(0);
        }
        
    }
}
