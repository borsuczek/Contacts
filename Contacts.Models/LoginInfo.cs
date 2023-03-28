using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    //class used as a help while a user is logging in
    public class LoginInfo
    {
        [EmailAddress]
        [Key]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
