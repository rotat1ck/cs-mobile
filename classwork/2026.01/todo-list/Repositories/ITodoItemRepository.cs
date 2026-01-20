using System;
using System.Collections.Generic;
using System.Text;
using todo_list.Models;

namespace todo_list.Repositories {
    public interface ITodoItemRepository {
        event EventHandler<TodoItem> OnItemAdded;
        event EventHandler<TodoItem> OnItemUpdated;

        Task<List<TodoItem>> GetItemsAsync();
        Task AddItemAsync(TodoItem item);
        Task UpdateItemAsync(TodoItem item);
        Task AddOrUpdateAsync(TodoItem item);
    }
}
