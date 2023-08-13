using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InterviewToDo.Models;
using InterviewToDo.Services;
using static System.Net.Mime.MediaTypeNames;

namespace InterviewToDo.ViewModels;
public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<TodoList> items;

    [RelayCommand]
    void Remove(TodoList item)
    {
        if (item == null)
            return;

        Items.Remove(item);
    }

    [RelayCommand]
    async Task Add()
    {
        string result = await Shell.Current.DisplayPromptAsync("New List", "");
        if (Items.Any(i => string.IsNullOrWhiteSpace(i.Name)))
            return;

        Items.Insert(0, new TodoList
        {
            Name = result,
            Todos = new ObservableCollection<TodoItem>(),
        });
    }

    public MainViewModel(IDataService dataService)
    {
        Items = new ObservableCollection<TodoList>(dataService.GetLists());
    }
}