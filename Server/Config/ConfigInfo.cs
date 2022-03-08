using System.Configuration;

namespace Server
{
    public class ConfigInfo
    {
        public string ConnectionString() 
        {
            return $"server={ConfigurationManager.AppSettings.Get("Server")};" +
                   $"database={ConfigurationManager.AppSettings.Get("Database")};" +
                   $"user={ConfigurationManager.AppSettings.Get("User")};" +
                   $"password={ConfigurationManager.AppSettings.Get("Password")}";
        }
        public string UrlString()
        {
            return ConfigurationManager.AppSettings.Get("Url");
        }
    }
}
