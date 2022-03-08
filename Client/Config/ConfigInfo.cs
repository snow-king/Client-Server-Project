using System.Configuration;

namespace Client
{
    public class ConfigInfo
    {
        public string UrlString() 
        {
            return ConfigurationManager.AppSettings.Get("Url");
        }
    }
}
