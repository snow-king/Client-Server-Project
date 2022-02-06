using System.ComponentModel.DataAnnotations;


namespace ASP_Server.Models
{
    public class StudyGroup
    {
        [Key]
        public int IdStudyGroups { get; set; }

        [Required]
        [MaxLength(15)]
        public string? NameGroup { get; set; }
    }
}
