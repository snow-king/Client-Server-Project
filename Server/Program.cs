using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: отдельный обект Runner для запуска исолнения и более удобного оборачивания в отдельный поток
            Console.WriteLine("Hello World!");
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
        }
    }
}
