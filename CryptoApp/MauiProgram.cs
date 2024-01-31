using CommunityToolkit.Maui;
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
            .UseMauiCommunityToolkit()
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
        mauiAppBuilder.Services.AddTransient<PortfolioPage>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ViewModels.MarketListViewModel>();
        mauiAppBuilder.Services.AddSingleton<ViewModels.SearchViewModel>();
        mauiAppBuilder.Services.AddSingleton<ViewModels.PortfolioViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ICoinGeckoService, CoinGeckoService>();
        mauiAppBuilder.Services.AddSingleton<ICryptoAppPortfolioService, CryptoAppPortfolioService>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterRepositories(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ICoinGeckoRepository, CoinGeckoRepository>();
        mauiAppBuilder.Services.AddSingleton<ICryptoAppDbRepository, CyptoAppDbRepository>();
        mauiAppBuilder.Services.AddSingleton<ICryptoAppSqliteRepository, CryptoAppSqliteRepository>();

        return mauiAppBuilder;
    }
}
