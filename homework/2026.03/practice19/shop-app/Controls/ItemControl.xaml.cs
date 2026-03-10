namespace shop_app.Controls;

public partial class ItemControl : Border {
    public static readonly BindableProperty ItemNameProperty =
        BindableProperty.Create(nameof(ItemName), typeof(string), typeof(ItemControl));

    public static readonly BindableProperty ItemPriceProperty =
        BindableProperty.Create(nameof(ItemPrice), typeof(decimal), typeof(ItemControl));

    public static readonly BindableProperty ItemRatingProperty =
        BindableProperty.Create(nameof(ItemRating), typeof(double), typeof(ItemControl));

    public static readonly BindableProperty ItemImageSourceProperty =
        BindableProperty.Create(nameof(ItemImageSource), typeof(ImageSource), typeof(ItemControl));

    public ImageSource ItemImageSource {
        get => (ImageSource)GetValue(ItemImageSourceProperty);
        set => SetValue(ItemImageSourceProperty, value);
    }

    public string ItemName {
        get => (string)GetValue(ItemNameProperty);
        set => SetValue(ItemNameProperty, value);
    }

    public decimal ItemPrice {
        get => (decimal)GetValue(ItemPriceProperty);
        set => SetValue(ItemPriceProperty, value);
    }

    public double ItemRating {
        get => (double)GetValue(ItemRatingProperty);
        set => SetValue(ItemRatingProperty, value);
    }

    public ItemControl() {
		InitializeComponent();
	}
}