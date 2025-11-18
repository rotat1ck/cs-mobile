namespace CollectionView {
    public partial class MainPage : ContentPage {
        public MainPage() {
            //InitializeComponent();
            Microsoft.Maui.Controls.CollectionView collectionView = new Microsoft.Maui.Controls.CollectionView {
                Margin = 5
            };

            collectionView.ItemsSource = new string[] {
                "Tom", "Ivan", "Oleg"
            };

            collectionView.ItemTemplate = new DataTemplate(() => {
                var personLabel = new Label {
                    FontSize = 16,
                    TextColor = Color.FromArgb("#1565C0")
                };

                personLabel.SetBinding(Label.TextProperty, new Binding(
                    "BindingContext", source: RelativeBindingSource.Self
                ));

                return personLabel;
            });

            Content = collectionView;
        }
    }

}
