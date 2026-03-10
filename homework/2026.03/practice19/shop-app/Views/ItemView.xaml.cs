using shop_app.Models;
using shop_app.ViewModels;
using System.Text.Json;

namespace shop_app.Views;

[QueryProperty(nameof(ItemJson), "itemJson")]
public partial class ItemView : ContentPage {
    public string ItemJson {
        set {
            var item = JsonSerializer.Deserialize<Item>(Uri.UnescapeDataString(value));
            ((ItemViewModel)BindingContext).Item = item;
        }
    }

    public ItemView(ItemViewModel vm) {
		InitializeComponent();
        BindingContext = vm;
	}
}