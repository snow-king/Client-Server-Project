using MySqlConnector;
using System;

namespace Server
{
    public class DBSelectsFuncs
    {
        MySqlConnection connection = null;
        public DBSelectsFuncs(MySqlConnection gettedConnection)
        {
            connection = gettedConnection;
        }

        public String getLessonsByProffesor(int professorId) {
            //вывести все занятия по id профессора
            String res = "";
            try
            {
                connection.Open();
                MySqlCommand profSel = new MySqlCommand("SELECT * FROM timetabledb.timetable WHERE idprofessors=@professorId;", connection);
                profSel.Parameters.AddWithValue("@professorId", proffesorId);
                profSel.Prepare();
                MySqlDataReader reader = profSel.ExecuteReader();

                while (reader.Read())
                {
                    res +=$" idshedule: {reader[0]}\n" +
                             $" idlesson_time: {reader[1]}\n" +
                             $" idweek_parity: {reader[2]}\n" +
                             $" idweekday: {reader[3]}\n" +
                             $" idclassroom: {reader[4]}\n" +
                             $" idstudy_groups: {reader[5]}\n" +
                             $" idprofessors: {reader[6]}\n" +
                             $" idlesson: {reader[7]}\n" +
                             $" idlesson_type: {reader[8]}"+"\n\n";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {
                connection.Close();
            }
            return res;
        }

        public String getAll()
        {
            //вывести всё что есть в главной таблице
            String res = "";
            try
            {
                connection.Open();
                MySqlCommand profSel = new MySqlCommand("SELECT * FROM timetabledb.timetable", connection);
                MySqlDataReader reader = profSel.ExecuteReader();
                while (reader.Read())
                {
                    res += $" idshedule: {reader[0]}\n" +
                             $" idlesson_time: {reader[1]}\n" +
                             $" idweek_parity: {reader[2]}\n" +
                             $" idweekday: {reader[3]}\n" +
                             $" idclassroom: {reader[4]}\n" +
                             $" idstudy_groups: {reader[5]}\n" +
                             $" idprofessors: {reader[6]}\n" +
                             $" idlesson: {reader[7]}\n" +
                             $" idlesson_type: {reader[8]}" + "\n\n";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {
                connection.Close();
            }
            return res;
        }
    }
}
