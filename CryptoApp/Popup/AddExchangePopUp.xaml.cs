using CryptoApp.Models;
using CryptoApp.Popup.Models;

namespace CryptoApp.Popup;

public partial class AddExchangePopUp : CommunityToolkit.Maui.Views.Popup
{
    private string _coinName = "";
    private string _symbol = "";
    private int _quantity = 0;
    private double _pricePurchasedAt = 0.0;

    public AddExchangePopUp()
	{
		InitializeComponent();
    }

    public string CoinName
    {
        get => _coinName;
        private set
        {
            if (_coinName != value)
            {
                _coinName = value;
                OnPropertyChanged();
            }
        }
    }

    public string Symbol
    {
        get => _symbol;
        private set
        {
            if (_symbol != value)
            {
                _symbol = value;
                OnPropertyChanged();
            }
        }
    }

    public int Quantity
    {
        get => _quantity;
        private set
        {
            if (_quantity != value)
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }
    }

    public double PricePurchasedAt
    {
        get => _pricePurchasedAt;
        private set
        {
            if (_pricePurchasedAt != value)
            {
                _pricePurchasedAt = value;
                OnPropertyChanged();
            }
        }
    }

    void OnSaveButtonClicked(object? sender, EventArgs e) => Close(new Exchange() {
        CoinId = CoinName,
        Amount = Quantity,
        PriceAtTime = PricePurchasedAt
    });

    void OnCancelButtonClicked(object? sender, EventArgs e) => Close(false);

    private void CoinNameChanged(object sender, TextChangedEventArgs e)
    {
        CoinName = e.NewTextValue;
    }

    private void SymbolChanged(object sender, TextChangedEventArgs e)
    {
        Symbol = e.NewTextValue;
    }

    private void QuantityChanged(object sender, TextChangedEventArgs e)
    {
        Quantity = int.Parse(e.NewTextValue);
    }

    private void PricePurchasedChanged(object sender, TextChangedEventArgs e)
    {
        PricePurchasedAt = double.Parse(e.NewTextValue);
    }
}