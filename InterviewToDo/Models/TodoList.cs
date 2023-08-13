using System;
namespace InterviewToDo.Models;

public class TodoList
{
    public string Name { get; set; }
    public IEnumerable<TodoItem> Todos { get; set; }
}
