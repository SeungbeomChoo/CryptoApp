using CryptoApp.Models;

namespace CryptoApp.Repositories.Interfaces
{
    public interface ICryptoAppDbRepository
    {
        Task<List<Exchange>> GetAllExchangeForUser(string user);
    }
}
