using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esraa_Store.Models.ViewModels
{
    public class LoginViewModel
    {
       
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
}
