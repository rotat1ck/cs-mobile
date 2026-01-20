using CommunityToolkit.Mvvm.ComponentModel;

namespace todo_list.ViewModels {
    [ObservableObject]
    public abstract partial class ViewModel {
        public INavigation Navigation { get; set; }
    }
}
