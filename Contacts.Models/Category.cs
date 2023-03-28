using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    //class describing fields that category has in data base
    public class Category
    {
        [Editable(false)]
        [Key]
        public string type { get; set; }
    }
}
