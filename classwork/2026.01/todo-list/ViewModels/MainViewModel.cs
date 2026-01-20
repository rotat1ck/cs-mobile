using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using todo_list.Models;
using todo_list.Repositories;
using todo_list.Views;

namespace todo_list.ViewModels {
    public partial class MainViewModel : ViewModel {
        private readonly ITodoItemRepository repository;
        private readonly IServiceProvider services;

        [ObservableProperty]
        private ObservableCollection<TodoItemViewModel> items;

        [ObservableProperty]
        private bool showAll;

        [RelayCommand]
        public async Task ToggleFilterAsync() {
            ShowAll = !ShowAll;
            await LoadDataAsync();
        }

        public MainViewModel(ITodoItemRepository repository, IServiceProvider services) {
            this.repository = repository;
            this.services = services;
            Task.Run(LoadDataAsync);

            repository.OnItemAdded += (s, e) => {
                items.Add(CreateTodoItemViewModel(e));
            };

            repository.OnItemUpdated += (s, e) => {
                Task.Run(async () => await LoadDataAsync());
            };
        }

        public async Task LoadDataAsync() {
            var items = await repository.GetItemsAsync();
            if (!ShowAll) {
                items = items.Where(i => !i.Completed).ToList();
            }

            var itemViewModels = items.Select(i => CreateTodoItemViewModel(i));
            Items = new ObservableCollection<TodoItemViewModel>(itemViewModels);
        }

        public TodoItemViewModel CreateTodoItemViewModel(TodoItem item) {
            var itemViewModel = new TodoItemViewModel(item);
            itemViewModel.ItemStatusChanged += ItemStatusChanged;
            return itemViewModel;
        }

        private void ItemStatusChanged(object sender, EventArgs e) {
            if (sender is TodoItemViewModel item) {
                if (!ShowAll && item.Item.Completed) {
                    Items.Remove(item);
                }
                Task.Run(async () => await repository.UpdateItemAsync(item.Item));
            }
        }

        [RelayCommand]
        public async Task AddItemAsync() => await Navigation.PushAsync(services.GetRequiredService<ItemView>());

        [ObservableProperty]
        private TodoItemViewModel selectedItem;

        partial void OnSelectedItemChanged(TodoItemViewModel value) {
            if (value == null) {
                return;
            }

            MainThread.BeginInvokeOnMainThread(async () => {
                await NavigateToItemAsync(value);
            });
        }

        private async Task NavigateToItemAsync(TodoItemViewModel item) {
            var itemView = services.GetRequiredService<ItemView>();
            var vm = itemView.BindingContext as TodoItemViewModel;
            vm.Item = item.Item;
            itemView.Title = "Edit todo item";

            await Navigation.PushAsync(itemView);
        }
    }
}
