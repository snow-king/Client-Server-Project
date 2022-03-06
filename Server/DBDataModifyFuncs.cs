using System;
using MySqlConnector;
using Server.Models;

namespace Server
{
    public class DBDataModifyFuncs
    {
        MySqlConnection connection = null;
        public DBDataModifyFuncs(MySqlConnection gettedConnection)
        {
            connection = gettedConnection;
        }

        /// <summary>
        /// Используется для занесения данных в таблицу Timetable
        /// </summary>
        /// <param name="lesstimeid"></param>
        /// <param name="chetid"></param>
        /// <param name="dayid"></param>
        /// <param name="roomid"></param>
        /// <param name="groupid"></param>
        /// <param name="proffesorid"></param>
        /// <param name="lessonid"></param>
        /// <param name="lesstypeid"></param>
        public void timetableIns(int lesstimeid, int chetid,int dayid, int roomid,int groupid, int proffesorid, int lessonid,int lesstypeid)
        {
            try
            {
                connection.Open();
                //main table fill
                MySqlCommand timetableIns = new MySqlCommand("INSERT INTO timetabledb.timetable " +
                    "(id_lesson_time, id_week_parity, id_week_day, id_classroom, id_study_groups,id_professors, id_discipline, id_lesson_type) " +
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


        /// <param name="data">Модель данных десериализованной из YAML-строки</param>
        public void timetableIns(Timetable data)
        {
            try
            {
                connection.Open();
                //main table fill
                MySqlCommand timetableIns = new MySqlCommand("INSERT INTO timetabledb.timetable " +
                    "(id_lesson_time, id_week_parity, id_weekday, id_classroom, id_study_groups,id_professors, id_lesson, id_lesson_type) " +
                "VALUES(@lesstime, @weekchet,@dayweek,@classroom,@group,@professor,@lesson,@lesstype);", connection);
                timetableIns.Parameters.AddWithValue("@lesstime", data.Id_lesson_time);
                timetableIns.Parameters.AddWithValue("@weekchet", data.Id_week_parity);
                timetableIns.Parameters.AddWithValue("@dayweek", data.Id_week_day);
                timetableIns.Parameters.AddWithValue("@classroom", data.Id_classroom);
                timetableIns.Parameters.AddWithValue("@group", data.Id_study_groups);
                timetableIns.Parameters.AddWithValue("@professor", data.Id_professors);
                timetableIns.Parameters.AddWithValue("@lesson", data.Id_discipline);
                timetableIns.Parameters.AddWithValue("@lesstype", data.Id_lesson_type);
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

        public void classroomIns(int classroom, String frame)
        {
            try
            {
                connection.Open();
                //classroom table fill
                MySqlCommand classroomIns = new MySqlCommand("INSERT INTO timetabledb.classroom (frame,number_classroom) VALUES (@frame,@classroom);", connection);
                classroomIns.Parameters.AddWithValue("@classroom", classroom);
                classroomIns.Parameters.AddWithValue("@frame", frame);
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
        public void disciplineIns(String discipline_name)
        {
            try
            {
                connection.Open();
                //discipline table fill
                MySqlCommand disciplineIns = new MySqlCommand("INSERT INTO timetabledb.discipline (name_discipline) VALUES (@discipline);", connection);
                disciplineIns.Parameters.AddWithValue("@discipline", discipline_name);
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
        public void facultyIns(String faculty_name)
        {
            try
            {
                connection.Open();
                //faculty table fill
                MySqlCommand facultyIns = new MySqlCommand("INSERT INTO timetabledb.faculty (name_faculty) VALUES (@faculty);", connection);
                facultyIns.Parameters.AddWithValue("@faculty", faculty_name);
                facultyIns.Prepare();
                facultyIns.ExecuteNonQuery();
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
        public void lesson_timeIns(int lesson_time, String lesson_start, String lesson_finish)
        {
            try
            {
                connection.Open();
                //lesson time table fill
                MySqlCommand lesson_timeIns = new MySqlCommand("INSERT INTO timetabledb.lesson_time (lesson_number, lesson_start, lesson_finish) VALUES (@lesson_time, @lesson_start, @lesson_finish);", connection);
                lesson_timeIns.Parameters.AddWithValue("@lesson_time", lesson_time);
                lesson_timeIns.Parameters.AddWithValue("@lesson_start", lesson_start);
                lesson_timeIns.Parameters.AddWithValue("@lesson_finish", lesson_finish);
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
                //lesson type table fill
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
        public void professorsIns(String name,String surname,String patronymic)
        {
            try
            {
                connection.Open();
                //professors table fill
                MySqlCommand professorsIns = new MySqlCommand("INSERT INTO timetabledb.professors (name,surname,patronymic) VALUES (@name,@surname,@patronymic);", connection);
                professorsIns.Parameters.AddWithValue("@name", name);
                professorsIns.Parameters.AddWithValue("@surname", surname);
                professorsIns.Parameters.AddWithValue("@patronymic", patronymic);
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
        public void specialityIns(String speciality_name, String abbreviated_speciality)
        {
            try
            {
                connection.Open();
                //speciality table fill
                MySqlCommand specialityIns = new MySqlCommand("INSERT INTO timetabledb.speciality (name_speciality,abbreviated_speciality) VALUES (@speciality_name,@abbreviated_speciality);", connection);
                specialityIns.Parameters.AddWithValue("@speciality_name", speciality_name);
                specialityIns.Parameters.AddWithValue("@abbreviated_speciality", abbreviated_speciality);
                specialityIns.Prepare();
                specialityIns.ExecuteNonQuery();
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
        public void study_groupsIns(String group_name,int id_faculty,int id_speciality,int course,String education_form)
        {
            try
            {
                connection.Open();
                //study group table fill
                MySqlCommand study_groupsIns = new MySqlCommand("INSERT INTO timetabledb.study_groups (name_group,id_faculty,id_speciality,course,form_education) " +
                    "VALUES (@group_name,@id_faculty,@id_speciality,@course,@education_form);", connection);
                study_groupsIns.Parameters.AddWithValue("@group_name", group_name);
                study_groupsIns.Parameters.AddWithValue("@id_faculty", id_faculty);
                study_groupsIns.Parameters.AddWithValue("@id_speciality", id_speciality);
                study_groupsIns.Parameters.AddWithValue("@course", course);
                study_groupsIns.Parameters.AddWithValue("@education_form", education_form);
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
                //week day table fill
                String week_day=inData;
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
                //week parity table fill
                String week_parity=inData;
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
