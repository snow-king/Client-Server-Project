using System;
using MySqlConnector;

namespace Server
{
    public class DBDataModifyFuncs
    {
        MySqlConnection connection = null;
        public DBDataModifyFuncs(MySqlConnection gettedConnection)
        {
            connection = gettedConnection;
        }
        public void timetableIns(int lesstimeid, int chetid,int dayid, int roomid,int groupid, int proffesorid, int lessonid,int lesstypeid)
        {
            try
            {
                connection.Open();
                //заполнение главной таблицы
                MySqlCommand timetableIns = new MySqlCommand("INSERT INTO timetabledb.timetable (idlesson_time, idweek_parity, idweekday, idclassroom, idstudy_groups,idprofessors, idlesson, idlesson_type) " +
                "VALUES(@lesstime, @weekchet,@dayweek,@classroom,@group,@professor,@lesson,@lesstype);", connection);
                timetableIns.Parameters.AddWithValue("@lesstime", lesstimeid);
                timetableIns.Parameters.AddWithValue("@weekchet", chetid);
                timetableIns.Parameters.AddWithValue("@dayweek", dayid);
                timetableIns.Parameters.AddWithValue("@classroom", roomid);
                timetableIns.Parameters.AddWithValue("@group", groupid);
                timetableIns.Parameters.AddWithValue("@professor", proffesorid);
                timetableIns.Parameters.AddWithValue("@lesson", lessonid);
                timetableIns.Parameters.AddWithValue("@lesstype", lesstypeid);
                timetableIns.Prepare();
                timetableIns.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {
                connection.Close();
            }
        }
        public void classroomIns(String inData)
        {
            try
            {
                connection.Open();
                //заполнение таблицы с аудиториями
                String classroom =inData;
                MySqlCommand classroomIns = new MySqlCommand("INSERT INTO timetabledb.classroom (location) VALUES (@classroom);", connection);
                classroomIns.Parameters.AddWithValue("@classroom", classroom);
                classroomIns.Prepare();
                classroomIns.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {
                connection.Close();
            }
        }
        public void disciplineIns(String inData)
        {
            try
            {
                connection.Open();
                //заполнение таблицы с предметами
                String discipline =inData;
                MySqlCommand disciplineIns = new MySqlCommand("INSERT INTO timetabledb.discipline (namediscipline) VALUES (@discipline);", connection);
                disciplineIns.Parameters.AddWithValue("@discipline", discipline);
                disciplineIns.Prepare();
                disciplineIns.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {
                connection.Close();
            }
        }
        public void lesson_timeIns(int inData)
        {
            try
            {
                connection.Open();
                //заполнение таблицы с занятиями
                MySqlCommand lesson_timeIns = new MySqlCommand("INSERT INTO timetabledb.lesson_time (lesson_number) VALUES (@lesson_time);", connection);
                lesson_timeIns.Parameters.AddWithValue("@lesson_time", inData);
                lesson_timeIns.Prepare();
                lesson_timeIns.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {
                connection.Close();
            }
        }
        public void lesson_typeIns(String inData)
        {
            try
            {
                connection.Open();
                //заполнение таблицы с видами занятий
                String lesson_type = inData;
                MySqlCommand lesson_typeIns = new MySqlCommand("INSERT INTO timetabledb.lesson_type (lesson_type) VALUES (@lesson_type);", connection);
                lesson_typeIns.Parameters.AddWithValue("@lesson_type", lesson_type);
                lesson_typeIns.Prepare();
                lesson_typeIns.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {
                connection.Close();
            }
        }
        public void professorsIns(String inData)
        {
            try
            {
                connection.Open();
                //заполнение таблицы с преподавателями
                String professors = inData;
                MySqlCommand professorsIns = new MySqlCommand("INSERT INTO timetabledb.professors (full_name) VALUES (@professors);", connection);
                professorsIns.Parameters.AddWithValue("@professors", professors);
                professorsIns.Prepare();
                professorsIns.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {
                connection.Close();
            }
        }
        public void study_groupsIns(String inData)
        {
            try
            {
                connection.Open();
                //заполнение таблицы с учебными группами
                String study_groups =inData;
                MySqlCommand study_groupsIns = new MySqlCommand("INSERT INTO timetabledb.study_groups (name_group) VALUES (@study_groups);", connection);
                study_groupsIns.Parameters.AddWithValue("@study_groups", study_groups);
                study_groupsIns.Prepare();
                study_groupsIns.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {
                connection.Close();
            }
        }
        public void week_dayIns(String inData)
        {
            try
            {
                connection.Open();
                //заполнение таблицы с днями недель
                String week_day =inData;
                MySqlCommand week_dayIns = new MySqlCommand("INSERT INTO timetabledb.week_day (weekday) VALUES (@week_day);", connection);
                week_dayIns.Parameters.AddWithValue("@week_day", week_day);
                week_dayIns.Prepare();
                week_dayIns.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {
                connection.Close();
            }
        }
        public void week_parityIns(String inData)
        {
            try
            {
                connection.Open();
                //заполнение таблицы с очередью недели
                String week_parity =inData;
                MySqlCommand week_parityIns = new MySqlCommand("INSERT INTO timetabledb.week_parity (week_parity) VALUES (@week_parity);", connection);
                week_parityIns.Parameters.AddWithValue("@week_parity", week_parity);
                week_parityIns.Prepare();
                week_parityIns.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
