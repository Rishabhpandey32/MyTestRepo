using NewMAUiApp.ViewModels;

namespace NewMAUiApp;

public partial class App : Application
{
	IServiceProvider _service;
	public App(IServiceProvider service)
	{
		InitializeComponent();

		MainPage = new NavigationPage(new ProductListPage());
	}
}
