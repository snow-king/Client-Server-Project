using System.Net;
using System.Net.Http.Headers;

namespace Client
{
    /**
    Класс для отправки POST запросов.
    
    +-------------------
    В коде нет документации.
    */
    public class Sender
    {
        string Url = "http://localhost:9911/timetable"; //TODO: добавить адрес сервера
		
        /**Метод для отправки yaml файла.
        Создает с помощью метода Create HTTP-запрос типа «POST»,
	используя URL-адрес в качестве параметра. Считывая yaml файл,
	отправляет POST запрос, который представляет собой массив
	байтов. Получает ответ от сервера.
	
	+-------------------
	В коде дублируется url адрес, можно оставить один
	*/
        public void UploadYamlFile(string FilePath) 
        {
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            try
            {
                var url = "http://localhost:9911/";

                var request = WebRequest.Create(url);
                request.Method = "POST";
                Stream stream = request.GetRequestStream();
                FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    stream.Write(buffer, 0, bytesRead);
                fileStream.Close();
                request.Timeout = 5000;
                using var webResponse = request.GetResponse();

            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
    }
}
