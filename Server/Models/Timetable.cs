namespace Server.Models
{
    public class Timetable
    {
        public int Id_schedule { get; set; }
        public int Id_lesson_time { get; set; }
        public int Id_week_parity { get; set; }
        public int Id_week_day { get; set; }
        public int Id_classroom { get; set; }
        public int Id_study_groups { get; set; }
        public int Id_professors { get; set; }
        public int Id_discipline { get; set; }
        public int Id_lesson_type { get; set; }



        /*public Timetable(string[] data)
        {
            Id_schedule = System.Convert.ToInt32(data[0]);
            Id_lesson_time = System.Convert.ToInt32(data[1]);
            Id_week_parity = System.Convert.ToInt32(data[2]);
            Id_week_day = System.Convert.ToInt32(data[3]);
            Id_classroom = System.Convert.ToInt32(data[4]);
            Id_study_groups = System.Convert.ToInt32(data[5]);
            Id_professors = System.Convert.ToInt32(data[6]);
            Id_discipline = System.Convert.ToInt32(data[7]);
            Id_lesson_type = System.Convert.ToInt32(data[8]);
        }*/
    }
}
