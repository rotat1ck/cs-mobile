using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using gallery_app.Models;
using gallery_app.Services;
using System.Collections.ObjectModel;

namespace gallery_app.ViewModels;

public partial class MainViewModel : ViewModel {
    private readonly IPhotoImporter photoImporter;
    private readonly ILocalStorage localStorage;

    [ObservableProperty]
    public ObservableCollection<Photo> recent;

    [ObservableProperty]
    public ObservableCollection<Photo> favourites;

    public MainViewModel(IPhotoImporter photoImporter, ILocalStorage localStorage) {
        this.photoImporter = photoImporter;
        this.localStorage = localStorage;
    }

    protected internal override async Task Initialize() {
        var photos = await photoImporter.Get(0, 20, Quality.Low);
        Recent = photos;
        await LoadFavourites();

        WeakReferenceMessenger.Default.Register<string>(this, async (sender, message) => {
            if (message == Services.Messages.FavouritesAddedMessage) {
                await MainThread.InvokeOnMainThreadAsync(LoadFavourites);
            }
        });
    }

    private async Task LoadFavourites() {
        var filenames = localStorage.Get();
        var favourites = await photoImporter.Get(filenames, Quality.Low);

        Favourites = favourites;
    }
}
