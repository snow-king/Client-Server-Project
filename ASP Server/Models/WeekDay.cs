using System.ComponentModel.DataAnnotations;

namespace ASP_Server.Models
{
    public class WeekDay
    {
        [Key]
        public int IdDay { get; set; }

        [Required]
        [MaxLength(15)]
        public string? Day { get; set; }
    }
}
