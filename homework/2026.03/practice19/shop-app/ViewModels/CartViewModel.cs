using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using shop_app.Models;
using shop_app.Services;

namespace shop_app.ViewModels;

public partial class CartViewModel(ICartService cartService) : ObservableObject {
    [ObservableProperty]
    private ICartService cartService = cartService;

    [RelayCommand]
    public async Task GoBack() {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task RemoveFromCart(Item item) {
        CartService.RemoveFromCart(item);
    }
}
