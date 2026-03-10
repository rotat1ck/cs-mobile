using System.Collections.ObjectModel;
using shop_app.Models;

namespace shop_app.Services;

public interface ICartService {
    ObservableCollection<Item> Items { get; set; }
    decimal TotalPrice { get; set; }
    void AddToCart(Item item);
    void RemoveFromCart(Item item);
}
