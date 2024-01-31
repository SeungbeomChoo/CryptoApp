using CryptoApp.Models;

namespace CryptoApp;

[QueryProperty(nameof(CryptoCurrency), "CryptoCurrency")]
public partial class CryptoDetailPage : ContentPage
{
	CryptoCurrency cryptoCurrency;
    public string allTimeHigh;
    public string allTimeLow;

    public CryptoCurrency CryptoCurrency
    {
        get => cryptoCurrency;
        set
        {
            cryptoCurrency = value;

            AllTimeHigh = $"${CryptoCurrency.AllTimeHigh} - {Math.Round((decimal)CryptoCurrency.AllTimeHighPercentage, 2)}%";
            AllTimeLow = $"${cryptoCurrency.AllTimeLow} - {Math.Round((decimal)CryptoCurrency.AllTimeLowPercentage, 2)}%";

            OnPropertyChanged();
        }
    }

    public string AllTimeHigh
    {
        get => allTimeHigh;
        set
        {
            allTimeHigh = value;
            OnPropertyChanged();
        }
    }

    public string AllTimeLow
    {
        get => allTimeLow;
        set
        {
            allTimeLow = value;
            OnPropertyChanged();
        }
    }

    public CryptoDetailPage()
	{
		InitializeComponent();
        BindingContext = this;
    }
}