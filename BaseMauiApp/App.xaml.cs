using BaseMauiApp;

namespace BaseMauiApp;

public partial class App : Application
{
	public App(AppShell shell)
	{
		InitializeComponent();

		MainPage = shell;
	}
}
