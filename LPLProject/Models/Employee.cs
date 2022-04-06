using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace LPLProject.Models
{
    public class Employee
    {
        [Key]

        [Display(Name = "Employee ID")]
        [Required(ErrorMessage = "* Employee ID Required.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only Numbers allowed.")]
        [StringLength(6, MinimumLength = 6,
                  ErrorMessage = "EMP ID should be only 6 digits.")]
        public string emp_ID { get; set; }
        [Required(ErrorMessage = "* First name required.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets allowed.")]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string first_Name { get; set; }
      
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "* Last name required.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets allowed.")]
        [StringLength(20)]
        public string last_Name { get; set; }
        [Required(ErrorMessage = "* Username required.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets allowed.")]
        [StringLength(20)]

        public string Username { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [Required(ErrorMessage = "* Password required.")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        
        [NotMapped]
        [Display(Name = "Confirm Password")]
        public string confirm_Password { get; set; }


    }
}