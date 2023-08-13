using InterviewToDo.Services;
using InterviewToDo.ViewModels;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace InterviewToDo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
            .UseMauiApp<App>()
			.UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<IDataService, DataService>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddTransient<DetailPage>();
        builder.Services.AddTransient<TodoListViewModel>();
        return builder.Build();
	}
}

