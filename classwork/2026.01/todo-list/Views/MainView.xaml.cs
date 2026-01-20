using todo_list.ViewModels;

namespace todo_list.Views;

public partial class MainView : ContentPage {
	public MainView(MainViewModel viewModel) {
		InitializeComponent();
		viewModel.Navigation = Navigation;
		BindingContext = viewModel;
	}
}