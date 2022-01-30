public void inserts() 
        {
            try
            {
                Connection.Open();
                /* in work
                MySqlCommand cmd = new MySqlCommand("INSERT INTO timetabledb.timetable VALUES(" +
                "SELECT iddiscipline FROM timetabledb.discipline WHERE namediscipline = @disc," +
                "SELECT iddiscipline FROM timetabledb.discipline WHERE namediscipline = @disc" +
                ");", Connection);
                cmd.Parameters.AddWithValue("@disc", "disc");
                cmd.Parameters.AddWithValue("@val2", "");*/

                //main table fill
                int chet_id, day_id,roomid,groupid,proffesorid,lessonid,lesstypeid;
                MySqlCommand timetableIns = new MySqlCommand("INSERT INTO timetabledb.timetable (week_chet_idweek_chet, day_week_iddayweek, classroom_idclassroom, study_groups_idstudy_groups, professors_idprofessors, lesson_idlesson, lesson_type_idtype_lesson) " +
                "VALUES(@weekchet,@dayweek,@classroom,@group,@professor,@lesson,@lesstype);", Connection);
                timetableIns.Parameters.AddWithValue("@weekchet", chet_id);
                timetableIns.Parameters.AddWithValue("@dayweek", day_id);
                timetableIns.Parameters.AddWithValue("@classroom", roomid);
                timetableIns.Parameters.AddWithValue("@group", groupid);
                timetableIns.Parameters.AddWithValue("@professor", proffesorid);
                timetableIns.Parameters.AddWithValue("@lesson", lessonid);
                timetableIns.Parameters.AddWithValue("@lesstype", lesstypeid);
                timetableIns.Prepare();
                timetableIns.ExecuteNonQuery();

                //classroom table fill
                String classroom;
                MySqlCommand classroomIns = new MySqlCommand("INSERT INTO timetabledb.classroom (location) VALUES (@classroom);", Connection);
                classroomIns.Parameters.AddWithValue("@classroom", classroom);
                classroomIns.Prepare();
                classroomIns.ExecuteNonQuery();

                //discipline table fill
                String discipline;
                MySqlCommand disciplineIns = new MySqlCommand("INSERT INTO timetabledb.discipline (namediscipline) VALUES (@discipline);", Connection);
                disciplineIns.Parameters.AddWithValue("@discipline", discipline);
                disciplineIns.Prepare();
                disciplineIns.ExecuteNonQuery();

                //lesson time table fill
                String lesson_time;
                MySqlCommand lesson_timeIns = new MySqlCommand("INSERT INTO timetabledb.lesson_time (lessonnumber) VALUES (@lesson_time);", Connection);
                lesson_timeIns.Parameters.AddWithValue("@lesson_time", lesson_time);
                lesson_timeIns.Prepare();
                lesson_timeIns.ExecuteNonQuery();

                //lesson type table fill
                String lesson_type;
                MySqlCommand lesson_typeIns = new MySqlCommand("INSERT INTO timetabledb.lesson_type (lesson_type) VALUES (@lesson_type);", Connection);
                lesson_typeIns.Parameters.AddWithValue("@lesson_type", lesson_type);
                lesson_typeIns.Prepare();
                lesson_typeIns.ExecuteNonQuery();

                //professors table fill
                String professors;
                MySqlCommand professorsIns = new MySqlCommand("INSERT INTO timetabledb.professors (full_name) VALUES (@professors);", Connection);
                professorsIns.Parameters.AddWithValue("@professors", professors);
                professorsIns.Prepare();
                professorsIns.ExecuteNonQuery();

                //study group table fill
                String study_groups;
                MySqlCommand study_groupsIns = new MySqlCommand("INSERT INTO timetabledb.study_groups (name_group) VALUES (@study_groups);", Connection);
                study_groupsIns.Parameters.AddWithValue("@study_groups", study_groups);
                study_groupsIns.Prepare();
                study_groupsIns.ExecuteNonQuery();

                //week day table fill
                String week_day;
                MySqlCommand week_dayIns = new MySqlCommand("INSERT INTO timetabledb.week_day (weekday) VALUES (@week_day);", Connection);
                week_dayIns.Parameters.AddWithValue("@week_day", week_day);
                week_dayIns.Prepare();
                week_dayIns.ExecuteNonQuery();

                //week parity table fill
                String week_parity;
                MySqlCommand week_parityIns = new MySqlCommand("INSERT INTO timetabledb.week_parity (week_chet) VALUES (@week_parity);", Connection);
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
                Connection.Close();
            }
        }