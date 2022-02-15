using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Server;
    
class Listener
{
    public static async Task Listen(SQLConnector con)
    {
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:9911/");
        listener.Start();
        Console.WriteLine("Ожидание подключений...");

        while (true)
        {
            HttpListenerContext context = await listener.GetContextAsync();
            Console.WriteLine("Подключение установленно");
            HttpListenerRequest request = context.Request;
            HttpParser parser = new HttpParser(request, con);
            HttpListenerResponse response = context.Response;

            //string responseString = "<html><head><meta charset='utf8'></head><body>Привет мир!</body></html>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(parser.Req);
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
    }
}
