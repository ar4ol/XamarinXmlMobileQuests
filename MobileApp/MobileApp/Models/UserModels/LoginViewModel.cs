using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Syncfusion.XForms.DataForm;

namespace MobileApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Login")]
        public string login { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }


    }
}
