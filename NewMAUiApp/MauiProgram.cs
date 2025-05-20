using Microsoft.Extensions.Logging;
using NewMAUiApp.Services;
using NewMAUiApp.ViewModels;


namespace NewMAUiApp;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddHttpClient<IAPIServices, APIServices>();
		builder.Services.AddSingleton<ProductListViewModel>();
		builder.Services.AddSingleton<ProductListPage>();
		builder.Services.AddSingleton<ProductDetailViewModel>();
		builder.Services.AddSingleton<DetailsPage>();

#if DEBUG
		builder.Logging.AddDebug();

#endif


		return builder.Build();
	}
	
}
