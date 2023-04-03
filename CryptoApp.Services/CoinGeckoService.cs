using CryptoApp.Models;
using CryptoApp.Repositories.Interfaces;
using CryptoApp.Services.Interfaces;

namespace CryptoApp.Services
{
    public class CoinGeckoService : ICoinGeckoService
    {
        private ICoinGeckoRepository _coinGeckoRepository;

        public CoinGeckoService(ICoinGeckoRepository coinGeckoRepository)
        {
            _coinGeckoRepository = coinGeckoRepository;
        }

        public async Task<List<CryptoCurrency>> GetTopCryptoCurrencies()
        {
            return await _coinGeckoRepository.GetTopCryptoCurrencies();
        }

        public async Task<List<CryptoCurrency>> GetAllCryptoCurrencies()
        {
            return await _coinGeckoRepository.GetAllCryptoCurrencies();
        }
    }
}
