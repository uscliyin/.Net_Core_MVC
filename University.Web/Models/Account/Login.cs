using System.ComponentModel.DataAnnotations;

namespace University.Web.Models.Account
{
    public class Login
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
