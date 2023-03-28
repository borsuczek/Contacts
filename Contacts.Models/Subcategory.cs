using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    //class describing fields that subcategory has in data base
    public class Subcategory
    {
        [Editable(false)]
        [Key]
        public string name { get; set; }
    }
}
