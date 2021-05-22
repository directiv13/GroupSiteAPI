using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GroupSiteAPI.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        public IEnumerable<UserChoice> UserChoices { get; set; }
    }
}