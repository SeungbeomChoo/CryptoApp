using CommunityToolkit.Maui.Views;
using CryptoApp.Models;
using CryptoApp.Popup;
using CryptoApp.Popup.Models;
using CryptoApp.ViewModels;

namespace CryptoApp;

public partial class PortfolioPage : ContentPage
{
	public PortfolioPage(PortfolioViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }

    public async void OnAddButtonClicked(object sender, EventArgs args)
    {
        var popup = new AddExchangePopUp();
        var result = await this.ShowPopupAsync(popup);

        if (result is Exchange)
        {
            var vm = (PortfolioViewModel)BindingContext;
            vm.AddExchange((Exchange)result);
        }
    }

}