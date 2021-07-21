using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace task_03_advanced_user_management_system.Models
{
    public class LoginModel
    {
        [Required (ErrorMessage ="This Field is Required......!")]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Please Enter Valid Email Address....!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field is Required......!")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}