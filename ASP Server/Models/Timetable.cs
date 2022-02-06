using System.ComponentModel.DataAnnotations;

namespace ASP_Server.Models
{
    public class Timetable
    {
        [Key]
        public int IdSchedule { get; set; }

        public LessonTime? LessonTime { get; set; }

        public WeekParity? WeekParity { get; set; }

        public WeekDay? WeekDay { get; set; }

        public Classroom? Classroom { get; set; }

        public StudyGroup? StudyGroup { get; set; }

        public Professor? Professor { get; set; }

        public Discipline? Discipline { get; set; }

        public LessonType? LessonType{ get; set; }
    }
}
