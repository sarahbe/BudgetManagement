using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetManagement.Models
{
    public class EntringTransaction
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string TransactionName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Display(Name = "TransactionTypeID")]
        public int TransactionTypeID { get; set; }
    }
}