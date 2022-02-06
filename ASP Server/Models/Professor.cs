using System.ComponentModel.DataAnnotations;


namespace ASP_Server.Models
{
    public class Professor
    {
        [Key]
        public int IdProfessors { get; set; }

        [Required]
        [MaxLength(100)]
        public string? FullName { get; set; }
    }
}
