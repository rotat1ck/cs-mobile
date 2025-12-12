using todo_app.Entities.Models;

namespace todo_app {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private void buttonSumbit_Clicked(object sender, EventArgs e) {
            TodoItem toDoItem = new TodoItem();

            toDoItem.Title = entryTitle.Text;
            toDoItem.Description = entryDescription.Text;
            toDoItem.IsDone = checkBoxIsDone.IsChecked;
            toDoItem.CompletionDate = datePickerCompletionDate.Date;

            labelToStringResult.Text = toDoItem.ToString();
        }
    }
}
