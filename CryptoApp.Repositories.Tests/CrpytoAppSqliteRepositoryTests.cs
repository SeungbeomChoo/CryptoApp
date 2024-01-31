using CryptoApp.Models;
using CryptoApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Repositories.Tests
{
    public class CrpytoAppSqliteRepositoryTests
    {
        private CryptoAppSqliteRepository _repo;
        private Exchange _testExchange;

        [SetUp]
        public void Setup()
        {
            _repo = new CryptoAppSqliteRepository();
            _testExchange = new Exchange
            {
                PriceAtTime = 1.0,
                CurrentPrice = 1.2,
                Average = 0,
                CoinId = "test",
                UserId = "testUser@test.com",
                Amount = 1
            };
        }

        [Test]
        public async Task CryptoSqliteSavesAndReturnsResult()
        {
            var result = await _repo.SaveExchange(_testExchange);

            Assert.IsNotNull(result);

            var output = await _repo.GetAllExchangeForUser("testUser@test.com");

            Assert.IsNotEmpty(output);

            await _repo.DeleteExchangesForUser(_testExchange);

            var outputAfterDelete = await _repo.GetAllExchangeForUser("testUser@test.com");

            Assert.IsEmpty(outputAfterDelete);
        }
    }
}
