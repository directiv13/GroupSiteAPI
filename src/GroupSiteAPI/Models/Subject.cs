using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
        public IEnumerable<Schedule> Schedule { get; set; }
    }
}