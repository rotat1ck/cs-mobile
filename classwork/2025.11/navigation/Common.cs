namespace navigation;

public class Common : ContentPage {
	public Common() {
		Title = "MyPage";
		Button back = new Button { Text = "Back", HorizontalOptions = LayoutOptions.Start };
		Label label = new Label { Text = "Test test test ..." };

		back.Clicked += async (o, e) => await Navigation.PopAsync();
		Content = new StackLayout { Children = { label, back } };	
	}
}