namespace navigation;

public class Page2 : ContentPage {
    Label stacklabel;

	public Page2() {
		Title = "Page 2";
        Button forward = new Button { Text = "Вперед" };
        forward.Clicked += ToForward;

        Button back = new Button { Text = "Назад" };
        back.Clicked += ToBack;

        stacklabel = new Label();


        Content = new StackLayout {
            Children = {
                forward, back, stacklabel
            }
        };
    }

    protected internal void DisplayStack() {
        if (Application.Current?.MainPage is NavigationPage navPage) {
            stacklabel.Text = "";
            foreach (Page p in navPage.Navigation.NavigationStack) {
                stacklabel.Text = $"{p.Title}\n{stacklabel.Text}";
            }
        }
    }

    private async void ToForward(object? sender, EventArgs e) {
        Page3 page = new Page3();
        await Navigation.PushAsync(page);
        DisplayStack();
    }

    private async void ToBack(object? sender, EventArgs e) {
        await Navigation.PopAsync();
        if (Application.Current?.MainPage is MainPage mainPage) {
            mainPage.DisplayStack();
        }
    }
}