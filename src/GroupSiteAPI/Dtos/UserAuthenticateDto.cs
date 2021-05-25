using System.ComponentModel.DataAnnotations;

namespace GroupSiteAPI.Dtos
{
    public class UserAuthenticateDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}