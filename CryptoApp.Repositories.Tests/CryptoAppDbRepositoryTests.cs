namespace CryptoApp.Repositories.Tests
{
    public class CryptoAppDbRepositoryTests
    {
        private CyptoAppDbRepository _repo;
        private string _testUser = "266300@nttdata.com";

        [SetUp]
        public void Setup()
        {
            _repo = new CyptoAppDbRepository();
        }

        [Test]
        public async Task GetAllExchangeForUserReturnsResult()
        {
            var result = await _repo.GetAllExchangeForUser(_testUser);

            Assert.IsNotEmpty(result);
        }
    }
}
