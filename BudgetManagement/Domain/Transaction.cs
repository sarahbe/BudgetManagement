﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Domain
{
    public class Transaction: BaseEntity
    {
        public string UserID { get; set; }
        public int AccountID { get; set; }
        public int TransactionTypeID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime? TransactionDate { get; set; }
        //Virtural Properties
        public virtual User User { get; set; }
        public virtual Account Account { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual Category Category { get; set; }
    }
}