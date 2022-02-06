using System.ComponentModel.DataAnnotations;


namespace ASP_Server.Models
{
    public class LessonTime
    {
        [Key]
        public int IdLessonTime { get; set; }

        [Required]
        public int LessonNumber { get; set; }
    }
}
