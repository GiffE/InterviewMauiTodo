using InterviewToDo.ViewModels;

namespace InterviewToDo;

public partial class DetailPage : ContentPage
{
	public DetailPage(TodoListViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}
