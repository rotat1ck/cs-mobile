using CommunityToolkit.Mvvm.ComponentModel;

namespace todo_list.ViewModels {
    [ObservableObject]
    internal partial class ViewModel {
        public INavigation Navigation { get; set; }

    }
}
