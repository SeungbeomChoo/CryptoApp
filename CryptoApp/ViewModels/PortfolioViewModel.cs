using CryptoApp.Models;
using CryptoApp.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CryptoApp.ViewModels
{
    public class PortfolioViewModel : INotifyPropertyChanged
    {
        private ICryptoAppPortfolioService _portfolioService;

        private List<Exchange> _exchangeList;
        private ObservableCollection<Exchange> _exchanges;
        private double _totalBoughtPrice;
        private double _totalCurrentPrice;

        public event PropertyChangedEventHandler PropertyChanged;

        public PortfolioViewModel(ICryptoAppPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;

            Task.Run(Initialize).Wait();
        }

        private async Task Initialize()
        {
            _exchangeList = await _portfolioService.GetExchangeForUser("266300@nttdata.com", "usd");
            _totalBoughtPrice = GetTotalBoughtPrice(_exchangeList);
            _totalCurrentPrice = GetTotalCurrentPrice(_exchangeList);

            _exchanges = new ObservableCollection<Exchange>(_exchangeList);

            Exchanges = _exchanges;
            TotalBoughtPrice = _totalBoughtPrice;
            TotalCurrentPrice = _totalCurrentPrice;
        }
        public ObservableCollection<Exchange> Exchanges
        {
            get => _exchanges;
            set
            {
                if (_exchanges != value)
                    _exchanges = value;

                OnPropertyChanged("Exchanges");
            }
        }

        public double TotalBoughtPrice
        {
            get => _totalBoughtPrice;
            set
            {
                if (_totalBoughtPrice != value)
                    _totalBoughtPrice = value;

                OnPropertyChanged("TotalBoughtPrice");
            }
        }

        public double TotalCurrentPrice
        {
            get => _totalCurrentPrice;
            set
            {
                if (_totalCurrentPrice != value)
                    _totalCurrentPrice = value;

                OnPropertyChanged("TotalCurrentPrice");
            }
        }

        private double GetTotalBoughtPrice(List<Exchange> exchanges)
        {
            double totalBoughtPrice = 0.0;

            exchanges.ForEach(x => { totalBoughtPrice += x.PriceAtTime * x.Amount; });

            return totalBoughtPrice;
        }

        private double GetTotalCurrentPrice(List<Exchange> exchanges)
        {
            double totalCurrentPrice = 0.0;

            exchanges.ForEach(x => { totalCurrentPrice += x.CurrentPrice * x.Amount; });

            return totalCurrentPrice;
        }

        public void AddExchange(Exchange exchange)
        {
            exchange.UserId = "266300@nttdata.com";
            _portfolioService.AddExchangeForUser(exchange);
            Initialize();
        }

        public void RemoveExchange(Exchange exchange)
        {
            exchange.UserId = "266300@nttdata.com";
            _portfolioService.RemoveExchangeForUser(exchange);
        }


        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
