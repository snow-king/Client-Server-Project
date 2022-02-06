using System.ComponentModel.DataAnnotations;

namespace ASP_Server.Models
{
    public class Classroom
    {
        [Key]
        public int IdClassroom { get; set; }
        
        [Required]
        [StringLength(50)]
        public string? Location { get; set; }                
    }
}
