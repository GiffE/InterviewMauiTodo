using InterviewToDo.Services;
using Microsoft.Maui.Platform;

namespace InterviewToDo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        Microsoft.Maui.Handlers.EntryHandler.Mapper.PrependToMapping(nameof(Entry), (handler, view) =>
        {
            if (view is Entry)
            {
#if ANDROID
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS || MACCATALYST
				handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
                
#endif
            }
        });
        MainPage = new AppShell();
    }
}

