using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Server;
    
class Listener
{
    public static async Task Listen(SQLConnector con)
    {
        var config = new ConfigInfo();
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add(config.UrlString());
        listener.Start();
        Console.WriteLine("Ожидание подключений...");

        while (true)
        {
            HttpListenerContext context = await listener.GetContextAsync();
            Console.WriteLine("Подключение установленно");
            HttpParser parser = new HttpParser(context, con);
        }
    }
}
