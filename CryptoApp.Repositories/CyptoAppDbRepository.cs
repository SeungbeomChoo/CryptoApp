using CryptoApp.Models;
using CryptoApp.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Repositories
{
    public class CyptoAppDbRepository : ICryptoAppDbRepository
    {
        private static string _connString = "Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=CryptoAppDb;Integrated Security=SSPI;Trusted_Connection=yes;";

        public async Task<List<Exchange>> GetAllExchangeForUser(string user)
        {
            var result = new List<Exchange>();

            var sql = $"SELECT * FROM dbo.Exchange Where PersonID = '{user}'";

            using var con = new SqlConnection(_connString);
            con.Open();

            var list = await con.QueryAsync<Exchange>(sql);
            result = list.ToList();

            return result;
        }
    }
}
