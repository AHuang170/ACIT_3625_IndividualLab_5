using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5.ViewModels
{
    public class SiteUserVM
    {
        [DisplayName("Enter Value for the 'First Name' Cookie")]
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }

        [DisplayName("Enter Value for the 'Last Name' Cookie")]
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }
    }
}
