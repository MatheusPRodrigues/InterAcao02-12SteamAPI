using MongoDB.Driver;

namespace Steam.API.Data
{
    public class AppDbContext
    {
        private readonly string _connectionString;

        public AppDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MongoConnection");
        }

        public IMongoDatabase GetConnection()
        {
            var client = new MongoClient(_connectionString);
            return client.GetDatabase("SteamAPI");
        }
    }
}
