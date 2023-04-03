using System;
using System.Collections.Generic;
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
        public async Task GeckoAPIReturnsResults()
        {
            var result = await _coinGeckoRepository.GetAllCryptoCurrencies();

            Assert.IsNotEmpty(result);
        }
    }
}
