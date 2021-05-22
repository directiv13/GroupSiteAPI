using System.ComponentModel.DataAnnotations;

namespace GroupSiteAPI.Models
{
    public class UserChoice
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}