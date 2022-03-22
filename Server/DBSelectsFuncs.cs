using MySqlConnector;
using System;

namespace Server
{
    public class DBSelectsFuncs
    {
		/*
		*Во всех методах используются подготовленные запросы
		*MySqlCommand.Parameters.AddWithValue() - Добавляет значение в конец коллекции SqlParameterCollection, 
											  эти значения являются фактическими данными, которые должны быть внесены в таблцы,
		*MySqlCommand.Prepare() - Создает подготовленную версию команды на экземпляре SQL Server,
		*MySqlCommand.ExecuteReader() - Отправляет CommandText в Connection и строит SqlDataReader.
		*/
        MySqlConnection connection = null;
        public DBSelectsFuncs(MySqlConnection gettedConnection)
        {
            connection = gettedConnection;
        }
        public String getLessonsByProffesorNSR(String proffesorName, String professorSurname, String professorPatronymic) {
            //print all lessons for selected by name, surname, patronymic professor
			/*
			*Печатает расписание, в кототрые ведет преподаватель с указанными именем (name), фамилией(surname) и отчеством (patronymic).
			*Данные получаем методом Select используя указанные выше параметры.
			*Рекомендуется изменить имя метода, так как правильно будет не Proffesor, а Professor. 
			*Также стоит изменить имя перменной proffesorName по тому же принципу.
			*/
            String res = "";
            try
            {
                connection.Open();
                MySqlCommand profSel = new MySqlCommand(
                    "SELECT timetabledb.professors.name, timetabledb.professors.surname, timetabledb.professors.patronymic, timetabledb.discipline.discipline_name, " +
                    "timetabledb.classroom.classroom_number, timetabledb.lesson_time.lesson_start, timetabledb.lesson_time.lesson_finish, timetabledb.lesson_type.lesson_type, " +
                    "timetabledb.study_groups.group_name, timetabledb.week_day.weekday, timetabledb.week_parity.week_parity, timetabledb.classroom.frame " +
                    "FROM timetabledb.timetable " +
                    "INNER JOIN  timetabledb.professors ON  timetabledb.professors.id_professors = timetabledb.timetable.id_professors " +
                    "INNER JOIN  timetabledb.classroom ON  timetabledb.classroom.id_classroom = timetabledb.timetable.id_classroom " +
                    "INNER JOIN  timetabledb.discipline ON  timetabledb.discipline.id_discipline = timetabledb.timetable.id_discipline " +
                    //"INNER JOIN  timetabledb.faculty ON  timetabledb.faculty.id_faculty = timetabledb.timetable.id_faculty " +
                    "INNER JOIN  timetabledb.lesson_time ON  timetabledb.lesson_time.id_lesson_time = timetabledb.timetable.id_lesson_time " +
                    "INNER JOIN  timetabledb.lesson_type ON  timetabledb.lesson_type.id_lesson_type = timetabledb.timetable.id_lesson_type " +
                   // "INNER JOIN  timetabledb.speciality ON   timetabledb.speciality.id_speciality = timetabledb.timetable.id_speciality " +
                    "INNER JOIN  timetabledb.study_groups ON  timetabledb.study_groups.id_study_groups = timetabledb.timetable.id_study_groups " +
                    "INNER JOIN  timetabledb.week_day ON  timetabledb.week_day.id_week_day = timetabledb.timetable.id_week_day " +
                    "INNER JOIN  timetabledb.week_parity ON  timetabledb.week_parity.id_week_parity = timetabledb.timetable.id_week_parity " +
                    "WHERE (timetabledb.professors.name = @professorName) " +
                    "AND timetabledb.professors.surname = @professorSurname " +
                    "AND timetabledb.professors.patronymic = @professorPatronymic ", connection);
                profSel.Parameters.AddWithValue("@professorName", proffesorName);
                profSel.Parameters.AddWithValue("@professorSurname", professorSurname);
                profSel.Parameters.AddWithValue("@professorPatronymic", professorPatronymic);
                profSel.Prepare();
                MySqlDataReader reader = profSel.ExecuteReader();
                int lessNum = 0;
                while (reader.Read())
                {
                    /*res +=
                        $" name: {reader[0]}\n" +
                        $" surname: {reader[1]}\n" +
                        $" patronymic: {reader[2]}\n" +
                        $" discipline_name: {reader[3]}\n" +
                        $" classroom: {reader[4]}\n" +
                        $" lesson_start: {reader[5]}\n" +
                        $" lesson_finish: {reader[6]}\n" +
                        $" lesson_type: {reader[7]}" + "\n" +
                        $" group: {reader[8]}\n" +
                        $" weekday: {reader[9]}\n" +
                        $" week_parity: {reader[10]}\n"+
                        $" frame: {reader[11]}\n\n";
                    i++;*/
                    lessNum++;
                    res += "   Занятие №"+lessNum+ Environment.NewLine +
                        "Дисциплина : "+reader[3] + Environment.NewLine +
                        "Аудитория : "+reader[11]+"-"+reader[4] + Environment.NewLine +
                        "Начало занятия : "+reader[5] + Environment.NewLine +
                        "Конец занятия : "+reader[6] + Environment.NewLine +
                        "Учебная группа : "+reader[8] + Environment.NewLine +
                        "ФИО Преподавателя : " + reader[1] + " " + reader[0] + " " + reader[2] + Environment.NewLine +
                        "День недели : " +reader[9] + Environment.NewLine +
                        "Тип недели : "+reader[10] + Environment.NewLine+Environment.NewLine;

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

        public String getLessonsByProffesorNSRDate(String proffesorName, String professorSurname, String professorPatronymic,String weekday,String parity)
        {
            //print all lessons for selected by name, surname, patronymic proffesssor
			/*
			*Печатает расписание, в кототрые ведет преподаватель с указанными именем (name), фамилией(surname) и отчеством (patronymic),
			*в указанный день недели(weekday) и с указанием четности недели(parity).
			*Данные получаем методом Select используя указанные выше параметры.
			*/
            String res = "";
            try
            {
                connection.Open();
                MySqlCommand profSel = new MySqlCommand(
                    "SELECT timetabledb.professors.name, timetabledb.professors.surname, timetabledb.professors.patronymic, timetabledb.discipline.discipline_name, " +
                    "timetabledb.classroom.classroom_number, timetabledb.lesson_time.lesson_start, timetabledb.lesson_time.lesson_finish, timetabledb.lesson_type.lesson_type, " +
                    "timetabledb.study_groups.group_name, timetabledb.week_day.weekday, timetabledb.week_parity.week_parity, timetabledb.classroom.frame " +
                    "FROM timetabledb.timetable " +
                    "INNER JOIN  timetabledb.professors ON  timetabledb.professors.id_professors = timetabledb.timetable.id_professors " +
                    "INNER JOIN  timetabledb.classroom ON  timetabledb.classroom.id_classroom = timetabledb.timetable.id_classroom " +
                    "INNER JOIN  timetabledb.discipline ON  timetabledb.discipline.id_discipline = timetabledb.timetable.id_discipline " +
                    //"INNER JOIN  timetabledb.faculty ON  timetabledb.faculty.id_faculty = timetabledb.timetable.id_faculty " +
                    "INNER JOIN  timetabledb.lesson_time ON  timetabledb.lesson_time.id_lesson_time = timetabledb.timetable.id_lesson_time " +
                    "INNER JOIN  timetabledb.lesson_type ON  timetabledb.lesson_type.id_lesson_type = timetabledb.timetable.id_lesson_type " +
                    // "INNER JOIN  timetabledb.speciality ON   timetabledb.speciality.id_speciality = timetabledb.timetable.id_speciality " +
                    "INNER JOIN  timetabledb.study_groups ON  timetabledb.study_groups.id_study_groups = timetabledb.timetable.id_study_groups " +
                    "INNER JOIN  timetabledb.week_day ON  timetabledb.week_day.id_week_day = timetabledb.timetable.id_week_day " +
                    "INNER JOIN  timetabledb.week_parity ON  timetabledb.week_parity.id_week_parity = timetabledb.timetable.id_week_parity " +
                    "WHERE (timetabledb.professors.name = @professorName) " +
                    "AND timetabledb.professors.surname = @professorSurname " +
                    "AND timetabledb.professors.patronymic = @professorPatronymic " +
                    "AND timetabledb.week_day.weekday = @weekday " +
                    "AND timetabledb.week_parity.week_parity = @parity ", connection);
                profSel.Parameters.AddWithValue("@professorName", proffesorName);
                profSel.Parameters.AddWithValue("@professorSurname", professorSurname);
                profSel.Parameters.AddWithValue("@professorPatronymic", professorPatronymic);
                profSel.Parameters.AddWithValue("@weekday", weekday);
                profSel.Parameters.AddWithValue("@parity", parity);
                profSel.Prepare();
                MySqlDataReader reader = profSel.ExecuteReader();

                int lessNum = 0;
                while (reader.Read())
                {
                    /*res +=
                        $" name: {reader[0]}\n" +
                        $" surname: {reader[1]}\n" +
                        $" patronymic: {reader[2]}\n" +
                        $" discipline_name: {reader[3]}\n" +
                        $" classroom: {reader[4]}\n" +
                        $" lesson_start: {reader[5]}\n" +
                        $" lesson_finish: {reader[6]}\n" +
                        $" lesson_type: {reader[7]}" + "\n" +
                        $" group: {reader[8]}\n" +
                        $" weekday: {reader[9]}\n" +
                        $" week_parity: {reader[10]}\n"+
                        $" frame: {reader[11]}\n\n";
                    i++;*/
                    lessNum++;
                    res += "   Занятие №" + lessNum + Environment.NewLine +
                        "Дисциплина : " + reader[3] + Environment.NewLine +
                        "Аудитория : " + reader[11] + "-" + reader[4] + Environment.NewLine +
                        "Начало занятия : " + reader[5] + Environment.NewLine +
                        "Конец занятия : " + reader[6] + Environment.NewLine +
                        "Учебная группа : " + reader[8] + Environment.NewLine +
                        "ФИО Преподавателя : " + reader[1] + " " + reader[0] + " " + reader[2] + Environment.NewLine +
                        "День недели : " + reader[9] + Environment.NewLine +
                        "Тип недели : " + reader[10] + Environment.NewLine + Environment.NewLine;

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
        public String getLessonsByGroup(String groupName)
        {
            //print all lessons for selected group
			/*
			*Печатает расписание, для заданной группы (groupName),
			*Данные получаем методом Select используя указанные выше параметры.
			*/
            String res = "";
            try
            {
                connection.Open();
                MySqlCommand groupSel = new MySqlCommand(
                    "SELECT timetabledb.professors.name, timetabledb.professors.surname, timetabledb.professors.patronymic, timetabledb.discipline.discipline_name, " +
                    "timetabledb.classroom.classroom_number, timetabledb.lesson_time.lesson_start, timetabledb.lesson_time.lesson_finish, timetabledb.lesson_type.lesson_type, " +
                    "timetabledb.study_groups.group_name, timetabledb.week_day.weekday, timetabledb.week_parity.week_parity, timetabledb.classroom.frame " +
                    "FROM timetabledb.timetable " +
                    "INNER JOIN  timetabledb.professors ON  timetabledb.professors.id_professors = timetabledb.timetable.id_professors " +
                    "INNER JOIN  timetabledb.classroom ON  timetabledb.classroom.id_classroom = timetabledb.timetable.id_classroom " +
                    "INNER JOIN  timetabledb.discipline ON  timetabledb.discipline.id_discipline = timetabledb.timetable.id_discipline " +
                    //"INNER JOIN  timetabledb.faculty ON  timetabledb.faculty.id_faculty = timetabledb.timetable.id_faculty " +
                    "INNER JOIN  timetabledb.lesson_time ON  timetabledb.lesson_time.id_lesson_time = timetabledb.timetable.id_lesson_time " +
                    "INNER JOIN  timetabledb.lesson_type ON  timetabledb.lesson_type.id_lesson_type = timetabledb.timetable.id_lesson_type " +
                    // "INNER JOIN  timetabledb.speciality ON   timetabledb.speciality.id_speciality = timetabledb.timetable.id_speciality " +
                    "INNER JOIN  timetabledb.study_groups ON  timetabledb.study_groups.id_study_groups = timetabledb.timetable.id_study_groups " +
                    "INNER JOIN  timetabledb.week_day ON  timetabledb.week_day.id_week_day = timetabledb.timetable.id_week_day " +
                    "INNER JOIN  timetabledb.week_parity ON  timetabledb.week_parity.id_week_parity = timetabledb.timetable.id_week_parity " +
                    "WHERE (timetabledb.study_groups.group_name = @groupName) " , connection);
                groupSel.Parameters.AddWithValue("@groupName", groupName);
                groupSel.Prepare();
                MySqlDataReader reader = groupSel.ExecuteReader();

                int lessNum = 0;
                while (reader.Read())
                {
                    /*res +=
                        $" name: {reader[0]}\n" +
                        $" surname: {reader[1]}\n" +
                        $" patronymic: {reader[2]}\n" +
                        $" discipline_name: {reader[3]}\n" +
                        $" classroom: {reader[4]}\n" +
                        $" lesson_start: {reader[5]}\n" +
                        $" lesson_finish: {reader[6]}\n" +
                        $" lesson_type: {reader[7]}" + "\n" +
                        $" group: {reader[8]}\n" +
                        $" weekday: {reader[9]}\n" +
                        $" week_parity: {reader[10]}\n"+
                        $" frame: {reader[11]}\n\n";
                    i++;*/
                    lessNum++;
                    res += "   Занятие №" + lessNum + Environment.NewLine +
                        "Дисциплина : " + reader[3] + Environment.NewLine +
                        "Аудитория : " + reader[11] + "-" + reader[4] + Environment.NewLine +
                        "Начало занятия : " + reader[5] + Environment.NewLine +
                        "Конец занятия : " + reader[6] + Environment.NewLine +
                        "Учебная группа : " + reader[8] + Environment.NewLine +
                        "ФИО Преподавателя : " + reader[1] + " " + reader[0] + " " + reader[2] + Environment.NewLine +
                        "День недели : " + reader[9] + Environment.NewLine +
                        "Тип недели : " + reader[10] + Environment.NewLine + Environment.NewLine;

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

        public String getLessonsByGroupDate(String groupName, String weekday, String parity)
        {
            //print all lessons for selected group
			/*
			*Печатает расписание, для заданной группы (groupName), в заданный день недели(weekday) и с заданой четностью/нечетностью недели(parity),
			*Данные получаем методом Select используя указанные выше параметры.
			*/
            String res = "";
            try
            {
                connection.Open();
                MySqlCommand groupSel = new MySqlCommand(
                    "SELECT timetabledb.professors.name, timetabledb.professors.surname, timetabledb.professors.patronymic, timetabledb.discipline.discipline_name, " +
                    "timetabledb.classroom.classroom_number, timetabledb.lesson_time.lesson_start, timetabledb.lesson_time.lesson_finish, timetabledb.lesson_type.lesson_type, " +
                    "timetabledb.study_groups.group_name, timetabledb.week_day.weekday, timetabledb.week_parity.week_parity, timetabledb.classroom.frame " +
                    "FROM timetabledb.timetable " +
                    "INNER JOIN  timetabledb.professors ON  timetabledb.professors.id_professors = timetabledb.timetable.id_professors " +
                    "INNER JOIN  timetabledb.classroom ON  timetabledb.classroom.id_classroom = timetabledb.timetable.id_classroom " +
                    "INNER JOIN  timetabledb.discipline ON  timetabledb.discipline.id_discipline = timetabledb.timetable.id_discipline " +
                    //"INNER JOIN  timetabledb.faculty ON  timetabledb.faculty.id_faculty = timetabledb.timetable.id_faculty " +
                    "INNER JOIN  timetabledb.lesson_time ON  timetabledb.lesson_time.id_lesson_time = timetabledb.timetable.id_lesson_time " +
                    "INNER JOIN  timetabledb.lesson_type ON  timetabledb.lesson_type.id_lesson_type = timetabledb.timetable.id_lesson_type " +
                    // "INNER JOIN  timetabledb.speciality ON   timetabledb.speciality.id_speciality = timetabledb.timetable.id_speciality " +
                    "INNER JOIN  timetabledb.study_groups ON  timetabledb.study_groups.id_study_groups = timetabledb.timetable.id_study_groups " +
                    "INNER JOIN  timetabledb.week_day ON  timetabledb.week_day.id_week_day = timetabledb.timetable.id_week_day " +
                    "INNER JOIN  timetabledb.week_parity ON  timetabledb.week_parity.id_week_parity = timetabledb.timetable.id_week_parity " +
                    "WHERE (timetabledb.study_groups.group_name = @groupName) " + 
                    "AND timetabledb.week_day.weekday = @weekday " +
                    "AND timetabledb.week_parity.week_parity = @parity ", connection);
                groupSel.Parameters.AddWithValue("@groupName", groupName);
                groupSel.Parameters.AddWithValue("@weekday", weekday);
                groupSel.Parameters.AddWithValue("@parity", parity);
                groupSel.Prepare();
                MySqlDataReader reader = groupSel.ExecuteReader();

                int lessNum = 0;
                while (reader.Read())
                {
                    /*res +=
                        $" name: {reader[0]}\n" +
                        $" surname: {reader[1]}\n" +
                        $" patronymic: {reader[2]}\n" +
                        $" discipline_name: {reader[3]}\n" +
                        $" classroom: {reader[4]}\n" +
                        $" lesson_start: {reader[5]}\n" +
                        $" lesson_finish: {reader[6]}\n" +
                        $" lesson_type: {reader[7]}" + "\n" +
                        $" group: {reader[8]}\n" +
                        $" weekday: {reader[9]}\n" +
                        $" week_parity: {reader[10]}\n"+
                        $" frame: {reader[11]}\n\n";
                    i++;*/
                    lessNum++;
                    res += "   Занятие №" + lessNum + Environment.NewLine +
                        "Дисциплина : " + reader[3] + Environment.NewLine +
                        "Аудитория : " + reader[11] + "-" + reader[4] + Environment.NewLine +
                        "Начало занятия : " + reader[5] + Environment.NewLine +
                        "Конец занятия : " + reader[6] + Environment.NewLine +
                        "Учебная группа : " + reader[8] + Environment.NewLine +
                        "ФИО Преподавателя : " + reader[1] + " " + reader[0] + " " + reader[2] + Environment.NewLine +
                        "День недели : " + reader[9] + Environment.NewLine +
                        "Тип недели : " + reader[10] + Environment.NewLine + Environment.NewLine;

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

        public String getLessonsByClassrom(String classroom, String frame)
        {
            //print all lessons for selected by classroom
			/*
			*Печатает расписание, для заданного кабинета(classroom) с указанием корпуса(frame),
			*Данные получаем методом Select используя указанные выше параметры.
			*/
            String res = "";
            try
            {
                connection.Open();
                MySqlCommand classSel = new MySqlCommand(
                    "SELECT timetabledb.professors.name, timetabledb.professors.surname, timetabledb.professors.patronymic, timetabledb.discipline.discipline_name, " +
                    "timetabledb.classroom.classroom_number, timetabledb.lesson_time.lesson_start, timetabledb.lesson_time.lesson_finish, timetabledb.lesson_type.lesson_type, " +
                    "timetabledb.study_groups.group_name, timetabledb.week_day.weekday, timetabledb.week_parity.week_parity, timetabledb.classroom.frame " +
                    "FROM timetabledb.timetable " +
                    "INNER JOIN  timetabledb.professors ON  timetabledb.professors.id_professors = timetabledb.timetable.id_professors " +
                    "INNER JOIN  timetabledb.classroom ON  timetabledb.classroom.id_classroom = timetabledb.timetable.id_classroom " +
                    "INNER JOIN  timetabledb.discipline ON  timetabledb.discipline.id_discipline = timetabledb.timetable.id_discipline " +
                    //"INNER JOIN  timetabledb.faculty ON  timetabledb.faculty.id_faculty = timetabledb.timetable.id_faculty " +
                    "INNER JOIN  timetabledb.lesson_time ON  timetabledb.lesson_time.id_lesson_time = timetabledb.timetable.id_lesson_time " +
                    "INNER JOIN  timetabledb.lesson_type ON  timetabledb.lesson_type.id_lesson_type = timetabledb.timetable.id_lesson_type " +
                    // "INNER JOIN  timetabledb.speciality ON   timetabledb.speciality.id_speciality = timetabledb.timetable.id_speciality " +
                    "INNER JOIN  timetabledb.study_groups ON  timetabledb.study_groups.id_study_groups = timetabledb.timetable.id_study_groups " +
                    "INNER JOIN  timetabledb.week_day ON  timetabledb.week_day.id_week_day = timetabledb.timetable.id_week_day " +
                    "INNER JOIN  timetabledb.week_parity ON  timetabledb.week_parity.id_week_parity = timetabledb.timetable.id_week_parity " +
                    "WHERE (timetabledb.classroom.classroom_number=@classroom) " +
                    "AND timetabledb.classroom.frame = @frame ", connection);
                classSel.Parameters.AddWithValue("@classroom", classroom);
                classSel.Parameters.AddWithValue("@frame", frame);
                classSel.Prepare();
                MySqlDataReader reader = classSel.ExecuteReader();

                int lessNum = 0;
                while (reader.Read())
                {
                    /*res +=
                        $" name: {reader[0]}\n" +
                        $" surname: {reader[1]}\n" +
                        $" patronymic: {reader[2]}\n" +
                        $" discipline_name: {reader[3]}\n" +
                        $" classroom: {reader[4]}\n" +
                        $" lesson_start: {reader[5]}\n" +
                        $" lesson_finish: {reader[6]}\n" +
                        $" lesson_type: {reader[7]}" + "\n" +
                        $" group: {reader[8]}\n" +
                        $" weekday: {reader[9]}\n" +
                        $" week_parity: {reader[10]}\n"+
                        $" frame: {reader[11]}\n\n";
                    i++;*/
                    lessNum++;
                    res += "   Занятие №" + lessNum + Environment.NewLine +
                        "Дисциплина : " + reader[3] + Environment.NewLine +
                        "Аудитория : " + reader[11] + "-" + reader[4] + Environment.NewLine +
                        "Начало занятия : " + reader[5] + Environment.NewLine +
                        "Конец занятия : " + reader[6] + Environment.NewLine +
                        "Учебная группа : " + reader[8] + Environment.NewLine +
                        "ФИО Преподавателя : " + reader[1] + " " + reader[0] + " " + reader[2] + Environment.NewLine +
                        "День недели : " + reader[9] + Environment.NewLine +
                        "Тип недели : " + reader[10] + Environment.NewLine + Environment.NewLine;

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

        public String getLessonsByClassromDate(String classroom, String frame, String weekday, String parity)
        {
            //print all lessons for selected by classroom
			/*
			*Печатает расписание, для заданного кабинета(classroom) с указанием корпуса(frame), в заданный день недели(weekday) с заданной четностью недели(parity),
			*Данные получаем методом Select используя указанные выше параметры.
			*/
            String res = "";
            try
            {
                connection.Open();
                MySqlCommand classSel = new MySqlCommand(
                    "SELECT timetabledb.professors.name, timetabledb.professors.surname, timetabledb.professors.patronymic, timetabledb.discipline.discipline_name, " +
                    "timetabledb.classroom.classroom_number, timetabledb.lesson_time.lesson_start, timetabledb.lesson_time.lesson_finish, timetabledb.lesson_type.lesson_type, " +
                    "timetabledb.study_groups.group_name, timetabledb.week_day.weekday, timetabledb.week_parity.week_parity, timetabledb.classroom.frame " +
                    "FROM timetabledb.timetable " +
                    "INNER JOIN  timetabledb.professors ON  timetabledb.professors.id_professors = timetabledb.timetable.id_professors " +
                    "INNER JOIN  timetabledb.classroom ON  timetabledb.classroom.id_classroom = timetabledb.timetable.id_classroom " +
                    "INNER JOIN  timetabledb.discipline ON  timetabledb.discipline.id_discipline = timetabledb.timetable.id_discipline " +
                    //"INNER JOIN  timetabledb.faculty ON  timetabledb.faculty.id_faculty = timetabledb.timetable.id_faculty " +
                    "INNER JOIN  timetabledb.lesson_time ON  timetabledb.lesson_time.id_lesson_time = timetabledb.timetable.id_lesson_time " +
                    "INNER JOIN  timetabledb.lesson_type ON  timetabledb.lesson_type.id_lesson_type = timetabledb.timetable.id_lesson_type " +
                    // "INNER JOIN  timetabledb.speciality ON   timetabledb.speciality.id_speciality = timetabledb.timetable.id_speciality " +
                    "INNER JOIN  timetabledb.study_groups ON  timetabledb.study_groups.id_study_groups = timetabledb.timetable.id_study_groups " +
                    "INNER JOIN  timetabledb.week_day ON  timetabledb.week_day.id_week_day = timetabledb.timetable.id_week_day " +
                    "INNER JOIN  timetabledb.week_parity ON  timetabledb.week_parity.id_week_parity = timetabledb.timetable.id_week_parity " +
                    "WHERE (timetabledb.classroom.classroom_number=@classroom) " +
                    "AND timetabledb.classroom.frame = @frame "+
                    "AND timetabledb.week_day.weekday = @weekday " +
                    "AND timetabledb.week_parity.week_parity = @parity ", connection);
                classSel.Parameters.AddWithValue("@classroom", classroom);
                classSel.Parameters.AddWithValue("@frame", frame);
                classSel.Parameters.AddWithValue("@weekday", weekday);
                classSel.Parameters.AddWithValue("@parity", parity);
                classSel.Prepare();
                MySqlDataReader reader = classSel.ExecuteReader();

                int lessNum = 0;
                while (reader.Read())
                {
                    /*res +=
                        $" name: {reader[0]}\n" +
                        $" surname: {reader[1]}\n" +
                        $" patronymic: {reader[2]}\n" +
                        $" discipline_name: {reader[3]}\n" +
                        $" classroom: {reader[4]}\n" +
                        $" lesson_start: {reader[5]}\n" +
                        $" lesson_finish: {reader[6]}\n" +
                        $" lesson_type: {reader[7]}" + "\n" +
                        $" group: {reader[8]}\n" +
                        $" weekday: {reader[9]}\n" +
                        $" week_parity: {reader[10]}\n"+
                        $" frame: {reader[11]}\n\n";
                    i++;*/
                    lessNum++;
                    res += "   Занятие №" + lessNum + Environment.NewLine +
                        "Дисциплина : " + reader[3] + Environment.NewLine +
                        "Аудитория : " + reader[11] + "-" + reader[4] + Environment.NewLine +
                        "Начало занятия : " + reader[5] + Environment.NewLine +
                        "Конец занятия : " + reader[6] + Environment.NewLine +
                        "Учебная группа : " + reader[8] + Environment.NewLine +
                        "ФИО Преподавателя : " + reader[1] + " " + reader[0] + " " + reader[2] + Environment.NewLine +
                        "День недели : " + reader[9] + Environment.NewLine +
                        "Тип недели : " + reader[10] + Environment.NewLine + Environment.NewLine;

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
			/*
			*Печатает все данные из таблицы Расписание (timetable)
			*/
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
