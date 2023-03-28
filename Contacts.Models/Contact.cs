using Contacts.Models.Validators;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    //class describing fields that contact has in data base
    public class Contact
    {
       
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        public string Surname { get; set; }
        [EmailAddress]
        [Key]
        public string Email { get; set; }
        [Required]
        [PasswordValidator]
        public string Password { get; set; }
        [DefaultValue("inny")]
        [Required]
        public string Category_type { get; set; } = "inny";
        [DefaultValue("brak")]
        public string Subcategory_name { get; set; } = "brak";
        [Phone]
        [Required]
        public string Phone { set; get; }
        [Required]
        public DateTime Birth_date { set; get; } = new DateTime(1990, 1, 1, 0, 0, 0);
    }
}
