using CryptoApp.Models;
using CryptoApp.Repositories.Interfaces;
using SQLite;

namespace CryptoApp.Repositories
{
    public class CryptoAppSqliteRepository : ICryptoAppSqliteRepository
    {
        SQLiteAsyncConnection Database;

        public const string DatabaseFilename = "CryptoSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;
        public static string DatabasePath => Path.Combine("/data/user/0/com.companyname.cryptoapp/files", DatabaseFilename);
        //public static string TestDatabasePath => Path.Combine("C:\\Users\\schoo", "CryptoSQLiteTest.db3");

        public CryptoAppSqliteRepository()
        {
            Task.Run(Init).Wait();
        }

        private async Task Init()
        {
            if (Database is not null)
                return;
            try
            {
                Database = new SQLiteAsyncConnection(DatabasePath, Flags);
                await Database.CreateTableAsync<Exchange>();
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public async Task<List<Exchange>> GetAllExchangeForUser(string user)
        {
            try
            {
                return await Database.Table<Exchange>().Where(i => i.UserId.Equals(user)).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> SaveExchange(Exchange exchange)
        {
            if (exchange.Id != 0)
            {
                return await Database.UpdateAsync(exchange);
            }
            else
            {
                return await Database.InsertAsync(exchange);
            }
        }

        public async Task<int> DeleteExchangesForUser(Exchange exchange)
        {
            return await Database.Table<Exchange>().DeleteAsync(x => x.UserId == exchange.UserId);
        }
    }
}
