using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetManagement.Models
{
    public class EntringTransaction
    {
        public int? ID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

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

        [Required]
        [Display(Name = "AccountId")]
        public int AccountId { get; set; }

        [Required]
        [Display(Name = "UserId")]
        public string UserId { get; set; }
        public int CategoryId { get;  set; }
        public bool Valid { get; set; }
    }
}