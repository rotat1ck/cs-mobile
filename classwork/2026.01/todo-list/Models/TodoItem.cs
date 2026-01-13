using SQLite;

namespace todo_list.Models {
    internal class TodoItem {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } 
        public string? Title { get; set; }
        public bool Completed { get; set; }
        public DateTime Due { get; set; }
    }
}
