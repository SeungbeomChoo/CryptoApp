using CryptoApp.Models;
using CryptoApp.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.Tests
{
    public class CoinGeckoServiceTests
    {
        private CoinGeckoService _service;

        private Mock<ICoinGeckoRepository> _coinGeckoRepository;

        private List<CryptoCurrency> _mockResult;

        [SetUp]
        public void Setup()
        {
            _coinGeckoRepository = new Mock<ICoinGeckoRepository>();

            _mockResult = new List<CryptoCurrency>() { new CryptoCurrency() { } };

            _coinGeckoRepository.Setup(_ => _.GetTopCryptoCurrencies()).Returns(() => Task.FromResult(_mockResult));
            _service = new CoinGeckoService(_coinGeckoRepository.Object);
        }

        [Test]
        public async Task GetAllCryptoCurrenciesReturnsList()
        {
            var result = await _service.GetAllCryptoCurrencies();

            Assert.IsNotEmpty(result);
            _coinGeckoRepository.Verify(d => d.GetTopCryptoCurrencies(), Times.Once);
        }
    }
}
