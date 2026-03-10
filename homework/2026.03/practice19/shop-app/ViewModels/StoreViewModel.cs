using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using shop_app.Models;
using shop_app.Services;
using System.Text.Json;

namespace shop_app.ViewModels;

public partial class StoreViewModel : ObservableObject {
    [ObservableProperty]
    private List<Item> items;

    public StoreViewModel() {
        Items = new() {
            new Item {
                ImageUri = "first_item.png",
                Name = "Avoine Hooded Quilted Jacket",
                Price = 1500,
                Rating = 4.5,          
            },
            new Item {
                ImageUri = "second_item.png",
                Name = "Wool Blend Overcoat",
                Price = 2200,
                Rating = 3.9,
            },
            new Item {
                ImageUri = "https://avatars.githubusercontent.com/u/182702594?v=4",
                Name = "Meow",
                Price = 99999,
                Rating = 10
            }
        };
    }

    [RelayCommand]
    public async Task ItemSelected(Item item) {
        var json = JsonSerializer.Serialize(item);
        await Shell.Current.GoToAsync($"itemPage?itemJson={Uri.EscapeDataString(json)}");
    }

    [RelayCommand]
    public async Task GotoCart() {
        await Shell.Current.GoToAsync("cartPage");
    }
}
