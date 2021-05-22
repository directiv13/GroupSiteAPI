using System.ComponentModel.DataAnnotations;

namespace GroupSiteAPI.Models
{
    public class Subject
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public bool IsElective { get; set; }
    }
}