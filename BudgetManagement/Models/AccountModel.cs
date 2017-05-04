using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetManagement.Models
{
    public class AccountModel
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Account Type ID")]
        public int AccountTypeID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string UserId { get; set; }

        public int CurrencyId { get; set; }

        public string Description { get; set; }
        public decimal? Limit { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Balance { get; set; }
        public bool Valid { get; set; }
    }
}