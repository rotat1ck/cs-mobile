using CommunityToolkit.Mvvm.ComponentModel;

namespace gallery_app.ViewModels;

public abstract partial class ViewModel : ObservableObject {
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool isBusy;

    public bool IsNotBusy => !IsBusy;

    abstract protected internal Task Initialize();
}
