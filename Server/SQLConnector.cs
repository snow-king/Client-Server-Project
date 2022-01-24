using MySqlConnector;
using System;

namespace Server
{
    /// <summary>
    /// Класс для создания подключения и исполнения запросов
    /// </summary>
    public class SQLConnector
    {
        public MySqlConnection Connection { get; private set; }
        private string ConnectionPath = "server=127.0.0.1;port=3306;user=TimetableAdmin;password=Aboba228"; // TODO: Получение пути подключения из файла

        /// <summary>
        /// Конструктор, при создании объекта будет проверена возможность осуществить подключение
        /// </summary>
        public SQLConnector() 
        {
            Connection = new MySqlConnection(ConnectionPath);
            try
            {
                Connection.Open();
                Console.WriteLine("Connection seccess!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Connection.Close();
            }
        }
        /// <summary>
        /// Метод получеющий всю таблицу Timetable
        /// </summary>
        /// <returns>Возвращает строку с полученной информацией</returns>
        public string SelectTimeTable() 
        {
            string result = "";
            string commandStr = "SELECT * FROM timetabledb.timetable;";
            //var idParam = new MySqlParameter("@id", id.ToString());
            MySqlCommand command;
            MySqlDataReader reader;

            try
            {
                Connection.Open();
                command = new MySqlCommand(commandStr, Connection);
                //command.Parameters.Add(idParam);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //for (int i = 0; i < 8; i++)
                    //    result += reader[i].ToString() + "\n";
                    result = $"idshedule: {reader[0]}\n" +
                             $"week_chet_idweek_chet: {reader[1]}\n" +
                             $"day_week_iddayweek: {reader[2]}\n" +
                             $"classroom_idclassroom: {reader[3]}\n" +
                             $"study_groups_iddstudy_groups: {reader[4]}\n" +
                             $"professors_idprofessors: {reader[5]}\n" +
                             $"lesson_idlesson: {reader[6]}\n" +
                             $"lesson_type_idtype_lesson: {reader[7]}\n";
                }



                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {
                Connection.Close();
            }

            return result;
        }
    }
}
