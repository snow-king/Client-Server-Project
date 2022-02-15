namespace Server.Models
{
    class Timetable
    {
        public int id_schedule { get; set; }
        public int id_lesson_time { get; set; }
        public int id_week_parity { get; set; }
        public int id_week_day { get; set; }
        public int id_classroom { get; set; }
        public int id_study_groups { get; set; }
        public int id_professors { get; set; }
        public int id_discipline { get; set; }
        public int id_lesson_type { get; set; }

        public Timetable(string[] data)
        {
            id_schedule = System.Convert.ToInt32(data[0]);
            id_lesson_time = System.Convert.ToInt32(data[1]);
            id_week_parity = System.Convert.ToInt32(data[2]);
            id_week_day = System.Convert.ToInt32(data[3]);
            id_classroom = System.Convert.ToInt32(data[4]);
            id_study_groups = System.Convert.ToInt32(data[5]);
            id_professors = System.Convert.ToInt32(data[6]);
            id_discipline = System.Convert.ToInt32(data[7]);
            id_lesson_type = System.Convert.ToInt32(data[8]);
        }
    }
}
