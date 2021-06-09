using Microsoft.Extensions.Configuration;

namespace TournamentApp.Model.ConfigManager
{
    public class DbConfigManager : IDbConfigManager
    {
        private readonly IConfiguration _configuration;

        public DbConfigManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString(string connectionName = "DefaultConnection")
        {
            return _configuration.GetConnectionString(connectionName);
        }

    }
}