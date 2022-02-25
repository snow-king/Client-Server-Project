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
        public String getLessonsByProffesor(int proffesorId) {
            //print all lessons for selected proffesssor
            String res = "";
            try
            {
                connection.Open();
                MySqlCommand profSel = new MySqlCommand("SELECT * FROM timetabledb.timetable WHERE id_professors=@professorId;", connection);
                profSel.Parameters.AddWithValue("@professorId", proffesorId);
                profSel.Prepare();
                MySqlDataReader reader = profSel.ExecuteReader();

                while (reader.Read())
                {
                    res +=$" idshedule: {reader[0]}\n" +
                             $" id_lesson_time: {reader[1]}\n" +
                             $" id_week_parity: {reader[2]}\n" +
                             $" id_weekday: {reader[3]}\n" +
                             $" id_classroom: {reader[4]}\n" +
                             $" id_study_groups: {reader[5]}\n" +
                             $" id_professors: {reader[6]}\n" +
                             $" id_lesson: {reader[7]}\n" +
                             $" id_lesson_type: {reader[8]}"+"\n\n";
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
            //print all from timetable
            String res = "";
            try
            {
                connection.Open();
                MySqlCommand profSel = new MySqlCommand("SELECT * FROM timetabledb.timetable", connection);
                MySqlDataReader reader = profSel.ExecuteReader();
                while (reader.Read())
                {
                    res += $" idshedule: {reader[0]}\n" +
                             $" id_lesson_time: {reader[1]}\n" +
                             $" id_week_parity: {reader[2]}\n" +
                             $" id_weekday: {reader[3]}\n" +
                             $" id_classroom: {reader[4]}\n" +
                             $" id_study_groups: {reader[5]}\n" +
                             $" id_professors: {reader[6]}\n" +
                             $" id_lesson: {reader[7]}\n" +
                             $" id_lesson_type: {reader[8]}" + "\n\n";
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
