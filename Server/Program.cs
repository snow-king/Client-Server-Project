using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: отдельный обект Runner для запуска исолнения и более удобного оборачивания в отдельный поток
            Runner runner = new Runner();
            runner.Run();
            
        }
    }

    /// <summary>
    /// Отдельный класс для запуска потока исполнения
    /// </summary>
    class Runner 
    {
        /// <summary>
        /// Метод старта основной программы
        /// </summary>
        public void Run() 
        {
            // TODO: вывести инфомрация из бд по нажатию любой кнопки
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить... ");
            Console.ReadKey();
            SQLConnector con = new SQLConnector();
            Console.WriteLine(con.SelectTimeTable());

            Console.ReadKey();
        }
    }
}
