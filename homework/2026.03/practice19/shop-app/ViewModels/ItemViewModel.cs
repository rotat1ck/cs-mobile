using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using shop_app.Models;

namespace shop_app.ViewModels;

public partial class ItemViewModel : ObservableObject {
    [ObservableProperty]
    private Item item;

    [RelayCommand]
    public async Task GoBack() {
        await Shell.Current.GoToAsync("..");
    }
}
