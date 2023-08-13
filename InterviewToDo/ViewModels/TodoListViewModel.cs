using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using InterviewToDo.Services;
using InterviewToDo.Models;
using static System.Net.Mime.MediaTypeNames;

namespace InterviewToDo.ViewModels;

[QueryProperty(nameof(Items), "Items")]
[QueryProperty(nameof(Name), "Name")]
public partial class TodoListViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<TodoItem> items;

    [ObservableProperty]
    string name;

    [RelayCommand]
    void Remove(TodoItem item)
    {
        if (item == null)
            return;

        Items.Remove(item);
    }

    [RelayCommand]
    void Unfocused(TodoItem item)
    {
        if (!string.IsNullOrWhiteSpace(item.Text))
            return;

        Items.Remove(item);
    }

    [RelayCommand]
    async Task Add()
    {
        // TODO: This should be moved to enable/disable the button.
        if (Items.Any(i => string.IsNullOrWhiteSpace(i.Text)))
            return;

        string result = await Shell.Current.DisplayPromptAsync("New Item", "");

        Items.Insert(0, new TodoItem
        {
            Text = result,
        });
    }
}