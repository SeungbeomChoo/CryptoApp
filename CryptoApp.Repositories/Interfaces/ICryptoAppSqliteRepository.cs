using CryptoApp.Models;

namespace CryptoApp.Repositories.Interfaces
{
    public interface ICryptoAppSqliteRepository
    {
        Task<List<Exchange>> GetAllExchangeForUser(string user);
        Task<int> SaveExchange(Exchange exchange);
        Task<int> DeleteExchangesForUser(Exchange exchange);
    }
}
