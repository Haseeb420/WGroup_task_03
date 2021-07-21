using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace task_03_advanced_user_management_system.Models
{
    public class ProfileModel
    {

        [Required(ErrorMessage = "This field can't be empty....!")]
        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "Frist Name can't be grater then 50 character...!")]
        [MinLength(2, ErrorMessage = "First Name can't be less then 2 character....!")]
        [DataType(DataType.Text)]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "This field can't be empty....!")]
        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "Last Name can't be grater then 50 character...!")]
        [MinLength(2, ErrorMessage = "Last Name can't be less then 2 character....!")]
        [DataType(DataType.Text)]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "This field can't be empty....!")]
        [Display(Name = "Email Address")]
        [MaxLength(30, ErrorMessage = "Email can't be grater then 50 character...!")]
        [MinLength(2, ErrorMessage = "Email Name can't be less then 2 character....!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter valid Email .....!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field can't be empty....!")]
        [DataType(DataType.Text)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "This field can't be empty....!")]
        [Display(Name = "Address 1")]
        [MaxLength(100, ErrorMessage = "Address 1 can't be grater then 50 character...!")]
        [MinLength(2, ErrorMessage = "Address 1 can't be less then 2 character....!")]
        [DataType(DataType.Text)]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "This field can't be empty....!")]
        [Display(Name = "Address 2")]
        [MaxLength(100, ErrorMessage = "Address 2 can't be grater then 50 character...!")]
        [MinLength(2, ErrorMessage = "Address 2 can't be less then 2 character....!")]
        [DataType(DataType.Text)]
        public string Address2 { get; set; }
    }
}