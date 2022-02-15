using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Server
{    
    class Program
    {
        static async Task Main(string[] args)
        {
            // TODO: отдельный обект Runner для запуска исолнения и более удобного оборачивания в отдельный поток
            Runner runner = new Runner();
            runner.Run();            

            await Listener.Listen(runner.Con);
        }
    }

    /// <summary>
    /// Отдельный класс для запуска потока исполнения
    /// </summary>
    class Runner 
    {        
        public SQLConnector Con { get; private set; }
        /// <summary>
        /// Метод старта основной программы
        /// </summary>
        public void Run() 
        {
            Con = new SQLConnector();            
        }
    }
}
