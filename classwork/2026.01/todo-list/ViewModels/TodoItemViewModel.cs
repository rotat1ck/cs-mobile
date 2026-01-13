using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using todo_list.Models;

namespace todo_list.ViewModels {
    internal partial class TodoItemViewModel : ViewModel {
        public TodoItemViewModel(TodoItem item) => Item = item;

        public event EventHandler ItemStatusChanged;

        [ObservableProperty]
        private TodoItem item;

        public string StatusText = Item.Completed ? "Reactivate" : "Completed";

        [RelayCommand]
        void ToggleCompleted() {
            Item.Completed = !Item.Completed;
            ItemStatusChanged?.Invoke(this, new EventArgs());
        }
    }
}
