using CryptoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.Interfaces
{
    public interface ICryptoAppPortfolioService
    {
        Task<List<Exchange>> GetExchangeForUser(string user, string currency);
        Task AddExchangeForUser(Exchange exchange);
        Task RemoveExchangeForUser(Exchange exchange);
    }
}
