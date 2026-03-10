using shop_app.ViewModels;

namespace shop_app.Views;

public partial class CartView : ContentPage
{
	public CartView(CartViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}