using MySqlConnector;
using System;
using YamlDotNet;
using Server.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

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
            //string result = "";
            string stringResult = "";
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

                string[] data = new string[9];

                while (reader.Read())
                {
                    
                    //result = $"idshedule: {reader[0]}\n" +
                    //         $"ddd: {reader[1]}\n" +
                    //         $"week_chet_idweek_chet: {reader[2]}\n" +
                    //         $"day_week_iddayweek: {reader[3]}\n" +
                    //         $"classroom_idclassroom: {reader[4]}\n" +
                    //         $"study_groups_iddstudy_groups: {reader[5]}\n" +
                    //         $"professors_idprofessors: {reader[6]}\n" +
                    //         $"lesson_idlesson: {reader[7]}\n" +
                    //         $"lesson_type_idtype_lesson: {reader[8]}\n";

                    for (int i = 0; i < 9; i++)
                    {
                        data[i] = reader[i].ToString();
                    }
                }

                
                var timetable = new Timetable(data);
                var serializer = new SerializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();
                
                stringResult = serializer.Serialize(timetable);
                Console.WriteLine(stringResult);
                
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

            return stringResult;
        }
    }
}
