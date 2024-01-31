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

        public static List<CryptoCurrency> AllCryptoList { get; set; } = new List<CryptoCurrency>();

        public SearchViewModel(ICoinGeckoService coinGeckoService)
        {
            _coinGeckoService = coinGeckoService;

            Task.Run(Initialize).Wait();
        }

        public async Task Initialize()
        {
            AllCryptoList = await _coinGeckoService.GetAllCryptoCurrencies();
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
