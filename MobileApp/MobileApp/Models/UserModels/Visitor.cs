using System;
using System.Collections.Generic;
using MobileApp.Locale;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Syncfusion.XForms.DataForm;

namespace MobileApp.Models
{
    public class Visitor
    {
        [Required(ErrorMessage = "Quest number is required")]
        [Display(Name = "Quest number", Order = 0)]
        public int questid { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Login",  Order = 0)]
        public string login { get; set; }

        [Display(AutoGenerateField = false)]
        public int zoneid { get; set; } = 0;

    }
}
