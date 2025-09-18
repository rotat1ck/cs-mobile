using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace todo_testapp.Model;

internal class TodoItem {
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool Completed { get; set; }
    public DateTime Due { get; set; }

}

