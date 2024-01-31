using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Repositories.Tests
{
    public class CoinGeckoRepositoryTests
    {
        private CoinGeckoRepository _coinGeckoRepository;

        [SetUp]
        public void Setup()
        {
            _coinGeckoRepository = new CoinGeckoRepository();
        }

        [Test]
        public async Task GeckoGetTopReturnsResults()
        {
            var result = await _coinGeckoRepository.GetTopCryptoCurrencies();

            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task GeckoGetAllReturnsResults()
        {
            var result = await _coinGeckoRepository.GetAllCryptoCurrencies();

            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task GeckoGetCurrentPricesReturnsResults()
        {
            var coinIds = new List<string>() { "bitcoin", "ethereum", "dogecoin", "tether", "binancecoin", "usd-coin", "ripple", "cardano", "staked-ether", "matic-network" };
            var result = await _coinGeckoRepository.GetCurrentPrices(coinIds, "usd");

            Assert.That(coinIds.Count, Is.EqualTo(result.Count));
        }
    }
}
