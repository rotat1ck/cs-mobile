using todo_list.ViewModels;

namespace todo_list.Views;

public partial class ItemView : ContentPage {
    public ItemView(ItemViewModel viewModel) {
		InitializeComponent();
		viewModel.Navigation = Navigation;
		BindingContext = viewModel;
	}
}