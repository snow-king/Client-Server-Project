using MySqlConnector;

namespace Server
{
    /// <summary>
    /// Класс для создания подключения и исполнения запросов
    /// </summary>
    public class SQLConnector
    {
        public MySqlConnection Connection { get; private set; }
        private string ConnectionPath = ""; // TODO: Получение пути подключения из файла

        /// <summary>
        /// Конструктор, при создании объекта будет проверена возможность осуществить подключение
        /// </summary>
        public SQLConnector() 
        {
            Connection = null;
        }
        /// <summary>
        /// Метод получеющий всю таблицу Timetable
        /// </summary>
        /// <returns>Возвращает строку с полученной информацией</returns>
        public string SelectTimeTable() 
        {

            return null;
        }
    }
}
