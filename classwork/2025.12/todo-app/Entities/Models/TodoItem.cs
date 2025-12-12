namespace todo_app.Entities.Models {
    internal class TodoItem {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime CompletionDate { get; set; }

        public override string ToString() {
            return $"{Title} - {IsDone}";
        }
    }
}
