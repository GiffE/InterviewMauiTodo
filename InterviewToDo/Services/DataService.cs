using System;
using System.Collections.ObjectModel;
using InterviewToDo.Models;

namespace InterviewToDo.Services
{
    public class DataService : IDataService
    {
        // TODO: Pull this list from persisted storage.
        private IEnumerable<TodoList> mockLists = new ObservableCollection<TodoList>() {
            new TodoList
            {
                Name = "Chores",
                Todos =  new ObservableCollection<TodoItem>()
                {
                    new TodoItem
                    {
                        Text = "Take out the trash"
                    },
                    new TodoItem
                    {
                        Text = "Run laundry"
                    },
                    new TodoItem
                    {
                        Text = "Clean Toilets"
                    },
                }
            }
        };
        public IEnumerable<TodoList> GetLists()
        {
            return mockLists;
        }
    }
}

