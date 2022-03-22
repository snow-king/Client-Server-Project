using System;
using MySqlConnector;
using Server.Models;

namespace Server
{
    public class DBDataModifyFuncs
    /*
	*Данный класс используется для занесения данных в таблицы
	*Во всех методах используются подготовленные запросы
	*MySqlCommand.Parameters.AddWithValue() - Добавляет значение в конец коллекции SqlParameterCollection, 
											  эти значения являются фактическими данными, которые должны быть внесены в таблцы,
	*MySqlCommand.Prepare() - Создает подготовленную версию команды на экземпляре SQL Server.,
	*MySqlCommand.ExecuteNonQuery() - Выполняет для подключения инструкцию Transact-SQL и возвращает количество задействованных в инструкции строк..
	*
    *connection - коннектор для подключения к базе данных
    */

    {
        MySqlConnection connection = null;
        public DBDataModifyFuncs(MySqlConnection gettedConnection)
        {
            connection = gettedConnection;
        }
		/*Данные используемые для XML документация*/
		
        /// <summary>
        /// Используется для занесения данных в таблицу Timetable
        /// </summary>
        /// <param name="lesstimeid"></param>
        /// <param name="chetid"></param>
        /// <param name="dayid"></param>
        /// <param name="roomid"></param>
        /// <param name="groupid"></param>
        /// <param name="professorid"></param>
        /// <param name="lessonid"></param>
        /// <param name="lesstypeid"></param>
        public void timetableIns(int lesstimeid, int chetid,int dayid, int roomid,int groupid, int proffesorid, int lessonid,int lesstypeid)
        {
			/*
			*Использую подготовленный запрос, вносим в таблицу timetable(Расписание) о:
			*lesstimeid - времени занятия,
			*chetid - четности/нечетности недели,
			*dayid - дне,
			*roomid - кабинете,
			*groupid - группе,
			*proffesorid - преподавателе,
			*lessonid - занятии,
			*lesstypeid - виде занятия.
			*Ловятся ошибки конструкцией try-catch. Параметры указываются в явном виде при вызове данного метода.			
			*/
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
			/*
			*Использую подготовленный запрос, вносим в данные полученные из YAML-строки в таблицу timetable(Расписание)
			*В отличие от прошлого метода, параметры передаются в виде специализированного объекта.			
			*/
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
			/*
			*В таблицу Кабинеты (classroom) вставляем данные:
			*classroom - номер кабинета,
			*frame - корпус здания
			*/
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
			/*
			*В таблицу Дисциплина (discipline) вставляем данные:
			*discipline_name - название дисциплины
			*/
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
			/*
			*В таблицу Факультет (faculty) вставляем данные:
			*faculty_name - название факультета
			*/
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
			/*
			*В таблицу Время занятий (lesson_time) вставляем данные:
			*lesson_time - порядковый номер занятия в течения дня,
			*lesson_start - время начала занятия,
			*lesson_finish - время конца занятия.
			*
			*Если база данных уже заполнена, вносить новые данные в эту таблицу явялется не желательным,
			*так как это нарушает логику функционирования унивреситета, все время занятий должно быть заранее внесено, а новых не должно быть предусмотренно 		
			*/
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
        public void lesson_typeIns(String lesson_type)
        {
			/*
			*В таблицу Вид занятия (lesson_type) вставляем данные:
			*lesson_type - тип занятия.
			*
			*На данный момент внос новых данных в эту таблицу не является необходимым, 
			*перечень видов занятий полный и исчерпывающий (лекции, семинары, лабораторные).
			*Может использоваться только для новой, пустой таблицы.
			*Во время ревью была исправлена ошибка по несовподению имени передаваемого параметра и имени используемого в методе.
			*/
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
			/*
			*В таблицу Преподаватели (professors) вставляем данные:
			*name - имя преподавателя,
			*surname - фамилия преподавателя,
			*patronymic - отчество преподавателя.
			*/
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
			/*
			*В таблицу Специальности (speciality) вставляем данные:
			*speciality_name - название специальности,
			*abbreviated_speciality - аббривиатура специальности.
			*/
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
			/*
			*В таблицу Учебные группы (study_groups) вставляем данные:
			*group_name - навзвание группы,
			*id_faculty - факультет,
			*id_speciality - специальность,
			*course - номер курса,
			*education_form - форма обучения.
			*/
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
        public void week_dayIns(String week_day)
        {
			/*
			*В таблицу День недели(week_day) вносим данные:
			*week_day - название деня недели.
			*Метод может использоваться только для незаполненых таблиц.
			*Если таблица День недели содержит все семь дней недели, данный метод является избыточным и вредным.
			*/
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
        public void week_parityIns(String week_parity)
        {
			/*
			*В таблицу Четность недели(week_parity) вносим данные:
			*week_parity - четность или нечетность недели.
			*Метод может использоваться только для незаполненых таблиц.
			*Если таблица Четность недели содержит два вида необходимых данных (чет и нечет), данный метод является избыточным и вредным.
			*/
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
