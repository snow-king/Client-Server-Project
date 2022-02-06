using System.ComponentModel.DataAnnotations;

namespace ASP_Server.Models
{
    public class WeekParity
    {
        [Key]
        public int IdweekParity { get; set; }

        [Required]
        [MaxLength(15)]
        public string? Parity { get; set; }
    }
}
