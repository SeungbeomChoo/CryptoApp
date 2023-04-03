using CryptoApp.Models;
using CryptoApp.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CryptoApp.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICoinGeckoService _coinGeckoService;

        private IList<CryptoCurrency> _allCryptoCurrencyList;

        public SearchViewModel(ICoinGeckoService coinGeckoService)
        {
            _coinGeckoService = coinGeckoService;

            Task.Run(Initialize).Wait();
        }

        public async Task Initialize()
        {
            _allCryptoCurrencyList = await _coinGeckoService.GetAllCryptoCurrencies();
            AllCryptoList = _allCryptoCurrencyList;
        }

        public IList<CryptoCurrency> AllCryptoList
        {
            get => _allCryptoCurrencyList;
            set
            {
                if (_allCryptoCurrencyList != value)
                    _allCryptoCurrencyList = value;

                OnPropertyChanged("AllCryptoList");
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
