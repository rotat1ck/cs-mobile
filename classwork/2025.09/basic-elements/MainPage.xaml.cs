namespace basic_elements {
    public partial class MainPage : ContentPage {
        public MainPage() {
            Grid grid = new Grid {
                RowDefinitions = {
                    new RowDefinition(),
                    new RowDefinition(),
                }, 
                ColumnDefinitions = {
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                }
            };
            grid.Add(new BoxView { Color = Color.FromRgba(0, 255, 255, 8) },0,0);
            grid.Add(new BoxView { Color = Color.FromRgba(0, 255, 255, 16) },0,1);

            grid.Add(new BoxView { Color = Color.FromRgba(0, 255, 255, 32) },1,0);
            grid.Add(new BoxView { Color = Color.FromRgba(0, 255, 255, 64) }, 1, 1);

            grid.Add(new BoxView { Color = Color.FromRgba(0, 255, 255, 128) }, 2, 0);
            grid.Add(new BoxView { Color = Color.FromRgba(0, 255, 255, 255) }, 2, 1);

            Content = grid;
            //InitializeComponent();
        }

    }

}
