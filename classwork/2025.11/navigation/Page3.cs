namespace navigation;

public class Page3 : ContentPage{
    Label stacklabel;

	public Page3(){
        Title = "Page 3";

        Button back = new Button { Text = "Назад" };
        back.Clicked += ToBack;

        stacklabel = new Label();
        Content = new StackLayout {
            Children = {
                back, stacklabel
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

    private async void ToBack(object? sender, EventArgs e) {
        await Navigation.PopAsync();
        if (Application.Current?.MainPage is NavigationPage navPage) {
            if (navPage.CurrentPage is Page2 page) {
                page.DisplayStack();
            }
        }
    }
}