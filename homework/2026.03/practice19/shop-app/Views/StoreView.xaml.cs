using shop_app.ViewModels;

namespace shop_app.Views;

public partial class StoreView : ContentPage {
	public StoreView(StoreViewModel vm) {
		InitializeComponent();
		BindingContext = vm;
	}
}