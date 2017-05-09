using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetManagement.Models
{
    public class UserRegistration
    {
        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        //[Display(Name = "Full-name")]
        //public string Fullname { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string Job { get; set; }

   
        public DateTime Birthdate { get; set; }

        public string MaritalStatus { get; set; }

    }
}