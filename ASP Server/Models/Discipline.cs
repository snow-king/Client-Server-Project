using System.ComponentModel.DataAnnotations;

namespace ASP_Server.Models
{
    public class Discipline
    {
        [Key]
        public int Iddiscipline { get; set; }

        [Required]
        [MaxLength(100)]
        public string? NameDiscipline { get; set; }
    }
}
