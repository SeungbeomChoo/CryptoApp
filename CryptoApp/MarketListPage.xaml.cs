using CryptoApp.ViewModels;

namespace CryptoApp;

public partial class MarketListPage : ContentPage
{
	public MarketListPage(MarketListViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }
}