using CryptoApp.ViewModels;

namespace CryptoApp;

public partial class SearchPage : ContentPage
{
	public SearchPage(SearchViewModel searchViewModel)
	{
		InitializeComponent();

        BindingContext = searchViewModel;
    }
}