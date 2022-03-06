using MySqlConnector;
using System;
using YamlDotNet;
using Server.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Collections.Generic;

namespace Server
{
    /// <summary>
    /// Класс для создания подключения и исполнения запросов
    /// </summary>
    public class SQLConnector
    {
        public MySqlConnection Connection { get; private set; }
        private string ConnectionPath; // TODO: Получение пути подключения из файла

        /// <summary>
        /// Конструктор, при создании объекта будет проверена возможность осуществить подключение
        /// </summary>
        public SQLConnector() 
        {
            var config = new ConfigInfo();
            ConnectionPath = config.ConnectionString();

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
            List<Timetable> timetables = new List<Timetable>();

            try
            {
                Connection.Open();
                command = new MySqlCommand(commandStr, Connection);
                //command.Parameters.Add(idParam);
                reader = command.ExecuteReader();

                string[] data = new string[9];
                
                while (reader.Read())
                {
                    var timetable = new Timetable();
                    timetable.Id_schedule = Convert.ToInt32(reader[0]);
                    timetable.Id_lesson_time = Convert.ToInt32(reader[1]);
                    timetable.Id_week_parity = Convert.ToInt32(reader[2]);
                    timetable.Id_week_day = Convert.ToInt32(reader[3]);
                    timetable.Id_classroom = Convert.ToInt32(reader[4]);
                    timetable.Id_study_groups = Convert.ToInt32(reader[5]);
                    timetable.Id_professors = Convert.ToInt32(reader[6]);
                    timetable.Id_discipline = Convert.ToInt32(reader[7]);
                    timetable.Id_lesson_type = Convert.ToInt32(reader[8]);

                    /*for (int i = 0; i < 9; i++)
                    {
                        data[i] = reader[i].ToString();
                    }*/

                    timetables.Add(timetable);
                }

                
                
                var serializer = new SerializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();
                
                stringResult = serializer.Serialize(timetables);
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
