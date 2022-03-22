using System;
using System.IO;
using System.Net;
using System.Net.Http.Headers; //(•ิ_•ิ)? (•ิ_•ิ)? (•ิ_•ิ)?

namespace Client
{
    // класс отправки запросов  ( без понятия зачем тут юрл константой, когда можно это в конструкторе задавать и
    // делать константной приватной поле )
    //  UploadYamlFile() - на вход получает путь файла который мы загружаем и юрл куда отправляем ямл файл 
    public class Sender
    {
        string Url = "http://localhost:9911/";
        
        // Класс отправки  Yaml на клиент
        // на вход получает путь файла который мы загружаем и юрл куда отправляем ямл файл 
        public void UploadYamlFile(string UrlPath, string FilePath) 
        {
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            try
            {
                var request = WebRequest.Create(Url + UrlPath);
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
