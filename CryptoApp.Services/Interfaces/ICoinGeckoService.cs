using CryptoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.Interfaces
{
    public interface ICoinGeckoService
    {
        Task<List<CryptoCurrency>> GetTopCryptoCurrencies();
        Task<List<CryptoCurrency>> GetAllCryptoCurrencies();
    }
}
