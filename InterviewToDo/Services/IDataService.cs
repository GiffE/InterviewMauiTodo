using System;
using InterviewToDo.Models;

namespace InterviewToDo.Services
{
    public interface IDataService
    {
        IEnumerable<TodoList> GetLists();
    }
}

