using Microsoft.Extensions.Configuration;

namespace TournamentApp.Model.ConfigManager
{
    public interface IDbConfigManager
    {
        string GetConnectionString(string connectionName = "DefaultConnection");

    }
}