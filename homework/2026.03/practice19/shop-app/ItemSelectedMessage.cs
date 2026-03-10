using CommunityToolkit.Mvvm.Messaging.Messages;
using shop_app.Models;

namespace shop_app;

public class ItemSelectedMessage : ValueChangedMessage<Item> {
    public ItemSelectedMessage(Item value) : base(value) { }
}
