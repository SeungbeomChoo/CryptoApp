using CryptoApp.Repositories;
using CryptoApp.Repositories.Interfaces;
using CryptoApp.Services;
using CryptoApp.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace CryptoApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .RegisterPages()
            .RegisterViewModels()
            .RegisterRepositories()
            .RegisterServices()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
    }

    public static MauiAppBuilder RegisterPages(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<MarketListPage>();
        mauiAppBuilder.Services.AddTransient<SearchPage>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ViewModels.MarketListViewModel>();
        mauiAppBuilder.Services.AddSingleton<ViewModels.SearchViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ICoinGeckoService, CoinGeckoService>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterRepositories(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ICoinGeckoRepository, CoinGeckoRepository>();

        return mauiAppBuilder;
    }
}
