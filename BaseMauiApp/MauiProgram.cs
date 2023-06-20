using BaseMauiApp.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Serilog;
using Serilog.Events;


namespace BaseMauiApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();


        //builder.ConfigureLifecycleEvents(events =>
        //{
        //    events.AddWindows(wndLifeCycleBuilder =>
        //    {
        //        wndLifeCycleBuilder.OnWindowCreated(window =>
        //        {
        //            window.ExtendsContentIntoTitleBar = false;
        //            IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
        //            WindowId myWndId = Win32Interop.GetWindowIdFromWindow(hWnd);
        //            var _appWindow = AppWindow.GetFromWindowId(myWndId);
        //            _appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);
        //        });
        //    });
        //});

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
        builder.Logging.AddSerilog(dispose: true);
        builder.Services.AddLogging();
        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddTransient<AppShell>();

        return builder.Build();
	}

    private static void SetupSerilog()
    {
        var flushInterval = new TimeSpan(0, 0, 1);
        var file = Path.Combine(FileSystem.AppDataDirectory, "visitorlog.log");

        Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.File(file, flushToDiskInterval: flushInterval, encoding: System.Text.Encoding.UTF8, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 22)
        .CreateLogger();
    }
}
