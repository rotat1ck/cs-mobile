namespace navigation;

public class Modal : ContentPage {
	public Modal() {
		Title = "Modal";
        Button back = new Button { Text = "Back", HorizontalOptions = LayoutOptions.Start };
        Label label = new Label { Text = "Test2 test2 test2 ..." };

        back.Clicked += async (o, e) => await Navigation.PopModalAsync();
        Content = new StackLayout { Children = { label, back } };
    }
}