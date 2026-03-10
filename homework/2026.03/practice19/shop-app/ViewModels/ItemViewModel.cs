using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using shop_app.Models;
using shop_app.Services;

namespace shop_app.ViewModels;

public partial class ItemViewModel : ObservableObject {
    private readonly ICartService cartService;

    [ObservableProperty]
    private Item item;

    public ItemViewModel(ICartService cartService) {
        this.cartService = cartService;
    }

    [RelayCommand]
    public async Task GoBack() {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task AddToCart() {
        cartService.AddToCart(Item);
        await Shell.Current.GoToAsync("..");
    }
}
