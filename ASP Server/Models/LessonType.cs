using System.ComponentModel.DataAnnotations;

namespace ASP_Server.Models
{
    public class LessonType
    {
        [Key]
        public int IdTypeLesson { get; set; }

        [Required]
        [MaxLength(45)]
        public string? Type { get; set; }
    }
}
