using CryptoApp.Models;
using CryptoApp.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CryptoApp.ViewModels
{
    public class MarketListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<CryptoCurrency> _cryptoCurrencyList;
        private ObservableCollection<CryptoCurrency> _cryptoCurrencies;

        private bool _24hSortedDesc = false;
        private bool _MarketSortedDesc = true;

        private ICoinGeckoService _coinGeckoService;

        public ICommand Sort24HCommand => new Command(() => SortBy24HPercentage());
        public Command SortMarketCapCommand => new Command(() => SortByMarketCap());

        public MarketListViewModel(ICoinGeckoService coinGeckoService)
        {
            _coinGeckoService = coinGeckoService;
              
            Task.Run(Initialize).Wait();
        }

        public async Task Initialize()
        {
            _cryptoCurrencyList = await _coinGeckoService.GetTopCryptoCurrencies();
            _cryptoCurrencies = new ObservableCollection<CryptoCurrency>(_cryptoCurrencyList);
            CryptoCurrencies = _cryptoCurrencies;
        }

        public ObservableCollection<CryptoCurrency> CryptoCurrencies
        {
            get => _cryptoCurrencies;
            set
            {
                if (_cryptoCurrencies != value)
                    _cryptoCurrencies = value;

                OnPropertyChanged("CryptoCurrencies");
            }
        }

        public void SortBy24HPercentage()
        {
            if (_24hSortedDesc)
            {
                _cryptoCurrencyList = _cryptoCurrencyList.OrderBy(x => x.Pricechange24hPercentage).ToList();
                _24hSortedDesc = false;
            }
            else {
                _cryptoCurrencyList = _cryptoCurrencyList.OrderByDescending(x => x.Pricechange24hPercentage).ToList();
                _24hSortedDesc = true;
            }

            _MarketSortedDesc = false;

            CryptoCurrencies = new ObservableCollection<CryptoCurrency>(_cryptoCurrencyList);
        }

        public void SortByMarketCap()
        {
            if (_MarketSortedDesc)
            {
                _cryptoCurrencyList = _cryptoCurrencyList.OrderBy(x => x.MarketCap).ToList();
                _MarketSortedDesc = false;
            }
            else
            {
                _cryptoCurrencyList = _cryptoCurrencyList.OrderByDescending(x => x.MarketCap).ToList();
                _MarketSortedDesc = true;
            }

            _24hSortedDesc = false;

            CryptoCurrencies = new ObservableCollection<CryptoCurrency>(_cryptoCurrencyList);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
