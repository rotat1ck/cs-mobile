using System.Collections.ObjectModel;
using shop_app.Models;

namespace shop_app.Services;

public class CartService : ICartService {
    public ObservableCollection<Item> Items { get; set; } = new();
    public decimal TotalPrice { get => Items.Sum(item => item.Price); set => field = value; }

    public void AddToCart(Item item) {
        if (!Items.Contains(item)) {
            Items.Add(item);
        }
    }

    public void RemoveFromCart(Item item) {
        Items.Remove(item);
    }
}
