using MobileApp.Locale;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MobileApp.Models.UserModels
{
    public class RegisterVisitor : Visitor
    {
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Order = 2)]
        public string password { get; set; }

      /*  [Display(AutoGenerateField = false)]
        public string role { get; set; } = "Owner";*/
    }
}
