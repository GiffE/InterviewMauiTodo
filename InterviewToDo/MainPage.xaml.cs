using System.Diagnostics;
using InterviewToDo.Models;
using InterviewToDo.ViewModels;

namespace InterviewToDo;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }

    // TODO: This is ugly, but I hacked this in just in brevity.  I'd probably
    // want to just do a tap gesture with a command to the vm.
    void todoLists_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        (sender as ListView).SelectedItem = null;
        if (e.SelectedItem == null)
            return;
        Dispatcher.DispatchAsync(async () =>
        {
            var item = e.SelectedItem as TodoList;
            var para = new Dictionary<string, object>
            {
                { "Items",  item.Todos},
                { "Name", item.Name }
            };
            await Shell.Current.GoToAsync(nameof(DetailPage), para);
        });
    }
}