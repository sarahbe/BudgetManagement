using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int AccountID { get; set; }
        public int TransactionTypeID { get; set; }
        public int CategoryID { get; set; }

        //Virtural Properties
        public virtual User User { get; set; }
        public virtual Account Account { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual Category Category { get; set; }
    }
}