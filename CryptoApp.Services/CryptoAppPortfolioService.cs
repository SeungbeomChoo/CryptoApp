using CryptoApp.Models;
using CryptoApp.Repositories.Interfaces;
using CryptoApp.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace CryptoApp.Services
{
    public class CryptoAppPortfolioService : ICryptoAppPortfolioService
    {
        private ICryptoAppDbRepository _cryptoAppDbRepository;
        private ICryptoAppSqliteRepository _cryptoAppSqliteRepository;
        private ICoinGeckoRepository _coinGeckoRepository;

        private List<string> _currencyIds;

        public CryptoAppPortfolioService(ICryptoAppDbRepository cryptoAppDbRepository,
            ICoinGeckoRepository coinGeckoRepository,
            ICryptoAppSqliteRepository cryptoAppSqliteRepository)
        {
            _cryptoAppDbRepository = cryptoAppDbRepository;
            _coinGeckoRepository = coinGeckoRepository;
            _cryptoAppSqliteRepository = cryptoAppSqliteRepository;

            _currencyIds = new List<string>();
        }

        public async Task AddExchangeForUser(Exchange exchange)
        {
            await _cryptoAppSqliteRepository.SaveExchange(exchange);
        }

        public async Task RemoveExchangeForUser(Exchange exchange)
        {
            await _cryptoAppSqliteRepository.DeleteExchangesForUser(exchange);
        }

        public async Task<List<Exchange>> GetExchangeForUser(string user, string currency)
        {
            var exchanges = await _cryptoAppSqliteRepository.GetAllExchangeForUser(user);

            _currencyIds = exchanges.Select(x => x.CoinId).Distinct().ToList();

            await GetExchangeCurrentPrices(exchanges, currency);
            GetAveragePriceForCurrency(exchanges);

            return exchanges;
        }

        private async Task GetExchangeCurrentPrices(List<Exchange> exchanges, string currency)
        {
            var currentPrices = await _coinGeckoRepository.GetCurrentPrices(_currencyIds, currency);

            exchanges.ForEach(ex =>
            {
                ex.CurrentPrice = currentPrices[ex.CoinId];
            });
        }

        private void GetAveragePriceForCurrency(List<Exchange> exchanges)
        {
            _currencyIds.ForEach(id =>
            {
                var avg = exchanges.Where(ex => ex.CoinId.Equals(id)).Select(ex2 => ex2.PriceAtTime).Average();
                exchanges.Where(ex => ex.CoinId.Equals(id)).ToList().ForEach(e => e.Average = avg);
            });
        }
    }
}
