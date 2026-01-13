using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using todo_list.Models;
using todo_list.Repositories;

namespace todo_list.ViewModels {
    internal partial class ItemViewModel : ViewModel {
        private readonly ITodoItemRepository repository;

        [ObservableProperty]
        private TodoItem item;

        public ItemViewModel(ITodoItemRepository repository) {
            this.repository = repository;
            Item = new TodoItem {
                Due = DateTime.Now.AddDays(1)
            };
        }

        [RelayCommand]
        public async Task SaveAsync() {
            await repository.AddOrUpdateAsync(Item);
            await Navigation.PopAsync();
        }
    }
}
