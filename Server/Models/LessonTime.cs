namespace Server.Models
{
    class LessonTime
    {
        public int Id_lesson { get; set; }
        public int Lesson_number { get; set; }
        public string Lesson_start { get; set; }
        public string Lesson_finish { get; set; }
        

        public LessonTime(string[] data)
        {
            Id_lesson = System.Convert.ToInt32(data[0]);
            Lesson_number = System.Convert.ToInt32(data[1]);
            Lesson_start = data[2];
            Lesson_finish = data[3];            
        }
    }
}
