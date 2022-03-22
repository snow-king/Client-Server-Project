using System.Configuration;

namespace Client
{
    /**
    Класс для работы с конфигурационным файлом.	
    
    +-------------------
    В коде нет документации.
    */
    public class ConfigInfo
    {
	/**Метод для получения url адреса. 
        Возвращает считанное из конфига значение поля Url.
	*/
        public string UrlString() 
        {
            return ConfigurationManager.AppSettings.Get("Url");
        }
    }
}
